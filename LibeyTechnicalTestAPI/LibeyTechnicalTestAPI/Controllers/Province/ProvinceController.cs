using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.Province
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceAggregate _aggregate;
        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{province}")]
        public IActionResult FindResponse(string province)
        {
            var row = _aggregate.FindResponse(province);
            return Ok(row);
        }
        [HttpPost]       
        public IActionResult Create(ProvinceUpdateorCreateCommand command)
        {
             _aggregate.Create(command);
            return Ok(true);
        }

        [HttpGet]
        [Route("FindByRegion")]
        public IActionResult FindByRegion([FromQuery]string? regionCode)
        {
            var row = _aggregate.FindByRegion(regionCode ?? "");
            return Ok(row);
        }
    }
}