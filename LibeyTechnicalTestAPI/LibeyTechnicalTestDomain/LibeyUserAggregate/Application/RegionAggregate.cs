using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
namespace LibeyTechnicalTestDomain.RegionAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }
        public void Create(RegionUpdateorCreateCommand command)
        {
            throw new NotImplementedException();
        }
        public RegionResponse FindResponse(string? documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public IList<RegionResponse> FindAllResponse(){
            var row = _repository.FindAllResponse();
            return row;
        }
    }
}