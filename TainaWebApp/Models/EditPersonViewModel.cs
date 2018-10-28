using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TainaWebApp.Models
{
    public class EditPersonViewModel
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public PersonModel PersonModel { get; set; }

        public EditPersonViewModel()
        {
            GenderList = new List<SelectListItem> {
                new SelectListItem { Text = "Male", Value = "Male" },
                new SelectListItem { Text = "Female", Value = "Female" }
            };
            PersonModel = new PersonModel();
        }
    }
}
