using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WakaWakaApi.DataAccess;
using WakaWakaApi.DTO;
using WakaWakaApi.Models;

namespace WakaWakaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WakaWakaDbContext Dbcontext;
        public RegionsController(WakaWakaDbContext DbContext)
        {
            this.Dbcontext = DbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = Dbcontext.Regions.ToList();
            var regionDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });

            }


            return Ok(regionDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = Dbcontext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
            {
                return NotFound();

            }
            var regionDto = new RegionDto() {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var regionmodelDomain = new Region()
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl,
                Id = Guid.NewGuid(),
            };
            Dbcontext.Regions.Add(regionmodelDomain);
            Dbcontext.SaveChanges();
            var regionDto = new RegionDto()
            {
                Id = regionmodelDomain.Id,
                Name = regionmodelDomain.Name,
                Code = regionmodelDomain.Code,
                RegionImageUrl = regionmodelDomain.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        
    }
}
