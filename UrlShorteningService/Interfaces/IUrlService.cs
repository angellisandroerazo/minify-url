using UrlShorteningService.Models;
using UrlShorteningService.Dtos;

namespace UrlShorteningService.Interfaces
{
    public interface IUrlService
    {
        Task<Url?> PostUrl(UrlString url);
        Task<UrlGet?> GetUrl(string shortCode);
        Task<Url?> StatsUrl(string shortCode);
    }
}
