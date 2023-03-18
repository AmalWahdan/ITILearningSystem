using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Controllers
{
    public class SessionDataController : Controller
    {
     

        public IActionResult SetSession()
        { 
            HttpContext.Session.SetString("Name", "Amal");
            HttpContext.Session.SetInt32("Age", 24);
            return Content("Success");
        }
      
        public IActionResult GetSession()
        {
            string Name = HttpContext.Session.GetString("Name");
            int Age = HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name :  {Name} & Age :  {Age}");

        }

        


    }
}
