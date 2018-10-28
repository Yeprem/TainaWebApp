using TainaWebApp.Service.Models;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Service
{
    public class MapperService : IMapperService
    {
        public IPerson MapPerson(PersonDto dto)
        {
            return new Person
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Surname,
                Gender = dto.Gender,
                Email = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber
            };
        }

        public PersonDto MapPersonDto(IPerson person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Surname = person.Lastname,
                Gender = person.Gender,
                EmailAddress = person.Email,
                PhoneNumber = person.PhoneNumber
            };
        }
    }
}
