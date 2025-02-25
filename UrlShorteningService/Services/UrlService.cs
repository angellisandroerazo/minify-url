using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using UrlShorteningService.Data;
using UrlShorteningService.Dtos;
using UrlShorteningService.Interfaces;
using UrlShorteningService.Models;

namespace UrlShorteningService.Services
{
    public class UrlService : IUrlService
    {

        private readonly UrlContext _context;

        public UrlService(UrlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Url>> GetUrls()
        {
            return await _context.Url.ToListAsync();
        }

        public async Task<Url?> PostUrl(UrlString url)
        {
            if (url.url == null)
            {
                return null;
            }

            var newUrl = new Url
            {
                id = Guid.NewGuid(),
                url = url.url,
                shortCode = Nanoid.Generate(size: 8),
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                accessCount = 0,
            };

            _context.Url.Add(newUrl);
            await _context.SaveChangesAsync();

            return newUrl;
        }

        public async Task<UrlGet?> GetUrl(string shortCode)
        {
            if (shortCode == null)
            {
                return null;
            }

            var url = await _context.Url.FirstOrDefaultAsync(f => f.shortCode == shortCode);
            if (url == null)
            {
                return null;
            }

            url.accessCount += 1;
            await _context.SaveChangesAsync();

            var result = new UrlGet
            {
                id = url.id,
                url = url.url,
                shortCode = url.shortCode,
                createdAt = url.createdAt,
                updatedAt = url.updatedAt,
            };

            return result;
        }

        public async Task<UrlGet?> PutUrl(string shortCode, UrlString url)
        {
            if (shortCode == null || url.url == null)
            {
                return null;
            }

            var existingUrl = await _context.Url.FirstOrDefaultAsync(f => f.shortCode == shortCode);
            if (existingUrl == null)
            {
                return null;
            }

            existingUrl.url = url.url;
            existingUrl.updatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlExists(existingUrl.id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            var result = new UrlGet
            {
                id = existingUrl.id,
                url = existingUrl.url,
                shortCode = existingUrl.shortCode,
                createdAt = existingUrl.createdAt,
                updatedAt = existingUrl.updatedAt,
            };
            return result;
        }

        public async Task<bool?> DeleteUrl(string shortCode)
        {
            if (shortCode == null)
            {
                return null;
            }

            var url = await _context.Url.FirstOrDefaultAsync(f => f.shortCode == shortCode);
            if (url == null)
            {
                return null;
            }

            _context.Url.Remove(url);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Url?> StatsUrl(string shortCode)
        {
            if (shortCode == null)
            {
                return null;
            }

            var url = await _context.Url.FirstOrDefaultAsync(f => f.shortCode == shortCode);

            if (url == null)
            {
                return null;
            }

            return url;
        }

        private bool UrlExists(Guid id)
        {
            return _context.Url.Any(e => e.id == id);
        }
    }
}