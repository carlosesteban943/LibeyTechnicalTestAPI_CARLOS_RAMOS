using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoRepository
    {
        UbigeoResponse FindResponse(string? documentNumber);
        IList<UbigeoResponse> FindByProvince(string regionCode, string provinceCode);
        void Create(Ubigeo Ubigeo);
    }
}
