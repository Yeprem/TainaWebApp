using System.Collections.Generic;
using System.Linq;
using TainaWebApp.Models;
using TainaWebApp.Service.Enums;
using TainaWebApp.Service.Models;
using TainaWebApp.Service.Services;

namespace TainaWebApp.ControllerService
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly ICacheService _cacheService;
        private readonly IDataService _dataService;

        public HomeControllerService(ICacheService cacheService,
            IDataService dataService)
        {
            _cacheService = cacheService;
            _dataService = dataService;
        }

        public IEnumerable<IPerson> GetPeople()
        {
            return _cacheService.GetOrAdd(CacheEntityNames.PersonList, () => _dataService.GetPeople(), null);
        }

        public IPerson GetPerson(long id)
        {
            return GetPeople().FirstOrDefault(x => x.Id == id);
        }

        public bool AddPerson(PersonModel person)
        {
            var result = _dataService.AddPerson(MapPerson(person));

            if (result)
            {
                _cacheService.Reset(CacheEntityNames.PersonList);
            }

            return result;
        }

        public bool UpdatePerson(PersonModel person)
        {
            var result = _dataService.UpdatePerson(MapPerson(person));

            if (result)
            {
                _cacheService.Reset(CacheEntityNames.PersonList);
            }

            return result;
        }

        private IPerson MapPerson(PersonModel model)
        {
            return new Person
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Gender = model.Gender,
                Email = model.Emailaddress,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}
