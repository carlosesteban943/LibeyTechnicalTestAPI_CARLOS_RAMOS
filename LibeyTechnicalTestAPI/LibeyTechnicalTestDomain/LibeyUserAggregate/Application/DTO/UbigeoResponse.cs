﻿namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO
{
    public record UbigeoResponse
    {
        public string UbigeoCode { get; init; }
        public string ProvinceCode { get; init; }
        public string RegionCode { get; init; }
        public string UbigeoDescription { get; init; }
        public bool Active { get; init; }


    }
}