using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }
        public void Create(Province Province)
        {
            _context.Provinces.Add(Province);
            _context.SaveChanges();
        }
        public ProvinceResponse FindResponse(string? province)
        {

            var q = from Provinces in _context.Provinces.Where(x => province == null || (x.ProvinceDescription.Contains(province) || x.ProvinceCode.ToString() == province))
                    select new ProvinceResponse()
                    {
                        ProvinceCode = Provinces.ProvinceCode,
                        ProvinceDescription = Provinces.ProvinceDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new ProvinceResponse();
        }


        public IList<ProvinceResponse> FindByRegion(string regionCode)
        {
             var q = from Provinces in _context.Provinces.Where(x => x.RegionCode == regionCode)
                    select new ProvinceResponse()
                    {
                        ProvinceCode = Provinces.ProvinceCode,
                        ProvinceDescription = Provinces.ProvinceDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<ProvinceResponse>();
        }
    }
}