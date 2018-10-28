namespace TainaWebApp.Service.Models
{
    public interface IPerson
    {
        long? Id { get; }
        string Firstname { get; }
        string Lastname { get; }
        string Email { get; }
        string Gender { get; }
        string PhoneNumber { get; }
    }

    public class Person : IPerson
    {
        public long? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
