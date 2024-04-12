namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO
{
    public record UbigeoUpdateorCreateCommand
    {
       public string UbigeoCode { get; init; }
        public string ProvinceCode { get; init; }
        public string RegionCode { get; init; }
        public string UbigeoDescription { get; init; }

    }
}