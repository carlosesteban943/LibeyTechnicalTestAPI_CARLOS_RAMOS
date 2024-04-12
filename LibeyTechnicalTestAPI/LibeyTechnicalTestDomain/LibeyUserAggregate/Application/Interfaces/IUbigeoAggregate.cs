using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        UbigeoResponse FindResponse(string? Ubigeo);
        IList<UbigeoResponse> FindByProvince(string regionCode,string provinceCode);
        void Create(UbigeoUpdateorCreateCommand  command);
    }
}