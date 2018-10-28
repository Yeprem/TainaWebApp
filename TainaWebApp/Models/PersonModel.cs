using System.ComponentModel.DataAnnotations;

namespace TainaWebApp.Models
{
    public class PersonModel
    {
        public long? Id { get; set; }
        [Required(ErrorMessage = "The First Name field is required")]
        [StringLength(30, MinimumLength = 1)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "The Last Name field is required")]
        [StringLength(40, MinimumLength = 1)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "The Gender field is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "The Email Address field is required")]
        [StringLength(200, MinimumLength = 1)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Inavlid Email Address" )]
        public string Emailaddress { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [RegularExpression(@"^\d+$")]
        public string PhoneNumber { get; set; }
    }
}
