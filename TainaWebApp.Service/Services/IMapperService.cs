using TainaWebApp.Service.Models;

namespace TainaWebApp.Service.Services
{
    public interface IMapperService
    {
        IPerson MapPerson(PersonDto dto);
        PersonDto MapPersonDto(IPerson person);
    }
}
