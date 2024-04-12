namespace LibeyTechnicalTestDomain.RegionAggregate.Application.DTO
{
    public record RegionUpdateorCreateCommand
    {
        public string RegionCode { get; init; }
        public string RegionDescription { get; init; }
    }
}