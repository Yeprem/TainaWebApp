using System.Collections.Generic;
using System.Linq;
using TainaWebApp.Service.Models;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Service
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IMapperService _mapperService;

        public DataService(IDataRepository dataRepository,
            IMapperService mapperService)
        {
            _dataRepository = dataRepository;
            _mapperService = mapperService;
        }

        public bool AddPerson(IPerson person)
        {
            return _dataRepository.TryAddPerson(_mapperService.MapPersonDto(person));
        }

        public IEnumerable<IPerson> GetPeople()
        {
            var result = new List<IPerson>();

            var data = _dataRepository.GetPeople();
            if (data != null)
            {
                result.AddRange(data.Select(x => _mapperService.MapPerson(x)));
            }

            return result;
        }

        public bool UpdatePerson(IPerson person)
        {
            return _dataRepository.TryUpdatePerson(_mapperService.MapPersonDto(person));
        }
    }
}
