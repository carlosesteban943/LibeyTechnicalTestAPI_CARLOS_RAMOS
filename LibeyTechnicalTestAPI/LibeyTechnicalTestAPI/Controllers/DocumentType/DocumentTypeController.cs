using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.DocumentType
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeAggregate _aggregate;
        public DocumentTypeController(IDocumentTypeAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentType}")]
        public IActionResult FindResponse([FromQuery] string documentType)
        {
            var row = _aggregate.FindResponse(documentType);
            return Ok(row);
        }
        [HttpPost]       
        public IActionResult Create(DocumentTypeUpdateorCreateCommand command)
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