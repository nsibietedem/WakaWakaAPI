using System.ComponentModel.DataAnnotations;

namespace WakaWakaApi.DTO
{
    public class RegionDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
