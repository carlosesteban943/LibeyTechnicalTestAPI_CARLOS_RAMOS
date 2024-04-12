using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        ProvinceResponse FindResponse(string? Province);
        IList<ProvinceResponse> FindByRegion(string regionCode);
        void Create(ProvinceUpdateorCreateCommand  command);
    }
}