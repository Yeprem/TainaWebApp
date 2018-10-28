using System.Collections.Generic;
using TainaWebApp.Service.Models;

namespace TainaWebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<IPerson> PersonList { get; set; }
    }
}
