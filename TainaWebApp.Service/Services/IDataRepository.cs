using System.Collections.Generic;
using TainaWebApp.Service.Models;

namespace TainaWebApp.Service.Services
{
    public interface IDataRepository
    {
        IEnumerable<PersonDto> GetPeople();
        bool TryAddPerson(PersonDto dto);
        bool TryUpdatePerson(PersonDto dto);
    }
}
