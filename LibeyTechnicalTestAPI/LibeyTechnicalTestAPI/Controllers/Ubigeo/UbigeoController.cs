using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoAggregate _aggregate;
        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{ubigeo}")]
        public IActionResult FindResponse(string ubigeo)
        {
            var row = _aggregate.FindResponse(ubigeo);
            return Ok(row);
        }
        [HttpPost]
        public IActionResult Create(UbigeoUpdateorCreateCommand command)
        {
            _aggregate.Create(command);
            return Ok(true);
        }

        [HttpGet]
        [Route("FindByProvince")]
        public IActionResult FindByProvince([FromQuery] string? regionCode, string? provinceCode)
        {
            var row = _aggregate.FindByProvince(regionCode ?? "", provinceCode ?? "");
            return Ok(row);
        }


    }
}