using Microsoft.AspNetCore.Mvc;
using TainaWebApp.ControllerService;
using TainaWebApp.Models;

namespace TainaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeControllerService _controllerService;

        public HomeController(IHomeControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        public IActionResult Index()
        {
            var result = _controllerService.GetPeople();
            var model = new HomeViewModel { PersonList = result };           

            return View(model);
        }  
        
        public IActionResult Edit(int id)
        {
            var result = _controllerService.GetPerson(id);

            if (result != null)
            {
                var model = new EditPersonViewModel
                {
                    PersonModel = new PersonModel
                    {
                        Id = result.Id,
                        Firstname = result.Firstname,
                        Lastname = result.Lastname,
                        Gender = result.Gender,
                        Emailaddress = result.Email,
                        PhoneNumber = result.PhoneNumber
                    }
                };

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _controllerService.UpdatePerson(model.PersonModel);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ErrorMessage = "An error occured while updating the person information.";
                }

                return View(model);
            }

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new EditPersonViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _controllerService.AddPerson(model.PersonModel);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ErrorMessage = "An error occured while adding the person to the list.";
                }

                return View(model);
            }

            return View(model);
        }
    }
}
