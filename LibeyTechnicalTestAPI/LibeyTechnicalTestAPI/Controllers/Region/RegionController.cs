using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionAggregate _aggregate;
        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{region}")]
        public IActionResult FindResponse(string region)
        {
            var row = _aggregate.FindResponse(region);
            return Ok(row);
        }
        [HttpPost]       
        public IActionResult Create(RegionUpdateorCreateCommand command)
        {
             _aggregate.Create(command);
            return Ok(true);
        }

         [HttpGet]
        [Route("FindAllResponse")]
        public IActionResult FindAllResponse()
        {
            var row = _aggregate.FindAllResponse();
            return Ok(row);
        }
    }
}