using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }
        public void Create(Ubigeo Ubigeo)
        {
            _context.Ubigeos.Add(Ubigeo);
            _context.SaveChanges();
        }
        public UbigeoResponse FindResponse(string? ubigeo)
        {

            var q = from Ubigeos in _context.Ubigeos.Where(x => ubigeo == null || x.UbigeoDescription.Contains(ubigeo) || x.UbigeoCode.ToString() == ubigeo)
                    select new UbigeoResponse()
                    {
                        UbigeoCode = Ubigeos.UbigeoCode,
                        UbigeoDescription = Ubigeos.UbigeoDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new UbigeoResponse();
        }


        public IList<UbigeoResponse> FindByProvince(string regionCode, string provinceCode)
        {
             var q = from Ubigeos in _context.Ubigeos.Where(x => x.RegionCode == regionCode && x.ProvinceCode == provinceCode)
                    select new UbigeoResponse()
                    {
                        UbigeoCode = Ubigeos.UbigeoCode,
                        UbigeoDescription = Ubigeos.UbigeoDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<UbigeoResponse>();
        }
    }
}