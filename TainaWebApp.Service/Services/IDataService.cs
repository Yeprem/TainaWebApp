using System.Collections.Generic;
using TainaWebApp.Service.Models;

namespace TainaWebApp.Service.Services
{
    public interface IDataService
    {
        IEnumerable<IPerson> GetPeople();
        bool AddPerson(IPerson person);
        bool UpdatePerson(IPerson person);
    }
}
