using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
namespace LibeyTechnicalTestDomain.RegionAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }
        public void Create(Region Region)
        {
            _context.Regions.Add(Region);
            _context.SaveChanges();
        }
        public RegionResponse FindResponse(string? region)
        {

            var q = from Regions in _context.Regions.Where(x => region == null || x.RegionDescription.Contains(region) || x.RegionCode.ToString() == region)
                    select new RegionResponse()
                    {
                        RegionCode = Regions.RegionCode,
                        RegionDescription = Regions.RegionDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new RegionResponse();
        }


        public IList<RegionResponse> FindAllResponse()
        {
             var q = from Regions in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = Regions.RegionCode,
                        RegionDescription = Regions.RegionDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<RegionResponse>();
        }
    }
}