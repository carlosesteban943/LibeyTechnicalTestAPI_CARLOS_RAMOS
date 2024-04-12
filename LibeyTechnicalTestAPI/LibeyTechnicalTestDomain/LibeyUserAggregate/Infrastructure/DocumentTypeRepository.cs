using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }
        public void Create(DocumentType DocumentType)
        {
            _context.DocumentTypes.Add(DocumentType);
            _context.SaveChanges();
        }
        public DocumentTypeResponse FindResponse(string? documentType)
        {

            var q = from DocumentType in _context.DocumentTypes.Where(x => documentType == null || x.DocumentTypeDescription.Contains(documentType) || x.DocumentTypeId.ToString() == documentType)
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = DocumentType.DocumentTypeId,
                        DocumentTypeDescription = DocumentType.DocumentTypeDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new DocumentTypeResponse();
        }


        public IList<DocumentTypeResponse> FindAllResponse()
        {
            var q = from DocumentType in _context.DocumentTypes
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = DocumentType.DocumentTypeId,
                        DocumentTypeDescription = DocumentType.DocumentTypeDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<DocumentTypeResponse>();
        }
    }
}