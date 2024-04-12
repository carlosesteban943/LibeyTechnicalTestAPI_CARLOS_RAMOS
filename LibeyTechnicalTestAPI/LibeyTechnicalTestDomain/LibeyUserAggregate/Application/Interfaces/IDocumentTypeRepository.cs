using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        DocumentTypeResponse FindResponse(string? documentNumber);
        IList<DocumentTypeResponse> FindAllResponse();
        void Create(DocumentType DocumentType);
    }
}
