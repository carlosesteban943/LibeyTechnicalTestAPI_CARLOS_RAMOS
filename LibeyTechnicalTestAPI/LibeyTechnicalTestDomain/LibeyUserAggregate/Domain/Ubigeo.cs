using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Domain
{
    public class Ubigeo
    {
        public string UbigeoCode { get; private set; }
        public string ProvinceCode { get; private set; }
        public string RegionCode { get; private set; }
        public string UbigeoDescription { get; private set; }

        public ICollection<LibeyUser> LibeyUsers { get; set; }

        public Region Region { get; set; }
        public Province Province { get; set; }


        public Ubigeo(string ubigeoCode, string provinceCode, string regionCode, string ubigeoDescription)
        {
            UbigeoCode = ubigeoCode;
            ProvinceCode = provinceCode;
            RegionCode = regionCode;
            UbigeoDescription = ubigeoDescription;
        }
    }
}
