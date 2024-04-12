using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceRepository
    {
        ProvinceResponse FindResponse(string? documentNumber);
        IList<ProvinceResponse> FindByRegion(string regionCode);
        void Create(Province Province);
    }
}
