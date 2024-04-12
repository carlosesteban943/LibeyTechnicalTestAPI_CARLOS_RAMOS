using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;
        public DocumentTypeAggregate(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }
        public void Create(DocumentTypeUpdateorCreateCommand command)
        {
            throw new NotImplementedException();
        }
        public DocumentTypeResponse FindResponse(string? documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public IList<DocumentTypeResponse> FindAllResponse(){
            var row = _repository.FindAllResponse();
            return row;
        }
    }
}