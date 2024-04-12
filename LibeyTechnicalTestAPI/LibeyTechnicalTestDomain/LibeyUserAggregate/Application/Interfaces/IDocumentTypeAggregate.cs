using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeAggregate
    {
        DocumentTypeResponse FindResponse(string? documentType);
        IList<DocumentTypeResponse> FindAllResponse();
        void Create(DocumentTypeUpdateorCreateCommand  command);
    }
}