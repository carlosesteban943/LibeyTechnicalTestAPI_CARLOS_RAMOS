using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;

namespace LibeyTechnicalTestDomain.RegionAggregate.Domain
{
    public class Region
    {
        public string RegionCode { get; private set; }
        public string RegionDescription { get; private set; }

        public ICollection<Ubigeo> Ubigeo { get; set; }


        public Region(string regionCode, string regionDescription)
        {
            RegionCode = regionCode;
            RegionDescription = regionDescription;
        }
    }
}
