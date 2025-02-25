using System.ComponentModel.DataAnnotations;

namespace UrlShorteningService.Dtos
{
    public class UrlString
    {
        public required string url { get; set; } 
    }

    public class UrlGet
    {
        public Guid id { get; set; }
        public required string url { get; set; }

        public string? shortCode { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
