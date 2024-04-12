namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO
{
    public record DocumentTypeUpdateorCreateCommand
    {
        public int DocumentTypeId { get; init; }
        public string DocumentTypeDescription { get; init; }
    }
}