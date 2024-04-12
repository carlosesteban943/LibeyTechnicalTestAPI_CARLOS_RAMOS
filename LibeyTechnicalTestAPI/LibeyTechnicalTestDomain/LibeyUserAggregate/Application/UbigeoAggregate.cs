using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;
        public UbigeoAggregate(IUbigeoRepository repository)
        {
            _repository = repository;
        }
        public void Create(UbigeoUpdateorCreateCommand command)
        {
            throw new NotImplementedException();
        }
        public UbigeoResponse FindResponse(string? documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public IList<UbigeoResponse> FindByProvince(string regionCode, string provinceCode){
            var row = _repository.FindByProvince(regionCode,provinceCode);
            return row;
        }
    }
}