using Microsoft.EntityFrameworkCore;
using UrlShorteningService.Models;

namespace UrlShorteningService.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options)
        : base(options)
        {
            
        }

        public DbSet<Url> Url { get; set; }
    }
}