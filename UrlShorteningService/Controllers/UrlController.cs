using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using UrlShorteningService.Dtos;
using UrlShorteningService.Interfaces;
using UrlShorteningService.Models;

namespace UrlShorteningService.Controllers
{
    [Route("/shorten")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        // GET: /shorten/abc123
        [HttpGet("{shortCode}")]
        public async Task<ActionResult<UrlGet>> GetUrl(string shortCode)
        {
           var url = await _urlService.GetUrl(shortCode);
            if (url == null)
            {
                return NotFound();
            }

            var result = new UrlGet
            {
                id = url.id,
                url = url.url,
                shortCode = url.shortCode,
                createdAt = url.createdAt,
                updatedAt = url.updatedAt,
            };

            return Ok(result);
        }

        // GET: /shorten/abc123/stats
        [HttpGet("{shortCode}/stats")]
        public async Task<ActionResult<Url>> GetUrlStats(string shortCode)
        {
            var result = await _urlService.StatsUrl(shortCode);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: /shorten
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UrlGet>> PostUrl(UrlString url)
        {
            var result = await _urlService.PostUrl(url);

            if (result == null)
            {
                return BadRequest();
            }

           return Ok(result);
        }
    }
}
