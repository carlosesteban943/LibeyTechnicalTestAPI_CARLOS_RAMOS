using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionRepository
    {
        RegionResponse FindResponse(string? documentNumber);
        IList<RegionResponse> FindAllResponse();
        void Create(Region Region);
    }
}
