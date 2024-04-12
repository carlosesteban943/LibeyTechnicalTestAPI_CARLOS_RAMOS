using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }
        public void Create(ProvinceUpdateorCreateCommand command)
        {
            throw new NotImplementedException();
        }
        public ProvinceResponse FindResponse(string? documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public IList<ProvinceResponse> FindByRegion(string regionCode){
            var row = _repository.FindByRegion(regionCode);
            return row;
        }
    }
}