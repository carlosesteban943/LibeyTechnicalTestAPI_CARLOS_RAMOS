using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionAggregate
    {
        RegionResponse FindResponse(string? Region);
        IList<RegionResponse> FindAllResponse();
        void Create(RegionUpdateorCreateCommand  command);
    }
}