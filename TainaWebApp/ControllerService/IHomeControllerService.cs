using System.Collections.Generic;
using TainaWebApp.Models;
using TainaWebApp.Service.Models;

namespace TainaWebApp.ControllerService
{
    public interface IHomeControllerService
    {
        IEnumerable<IPerson> GetPeople();
        IPerson GetPerson(long id);
        bool AddPerson(PersonModel person);
        bool UpdatePerson(PersonModel person);
    }
}
