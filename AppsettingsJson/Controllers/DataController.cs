using AppsettingsJson.Models;
using AppsettingsJson.Servicves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;

namespace AppsettingsJson.Controllers
{
    public class DataController : Controller
    {
        private readonly IOptions<DataModelService> _options; // using IOptions interface

        public DataController(IOptions<DataModelService> options) // dependency injection
        {
            _options = options;
        }
        public IActionResult Index1() // passing datas by ViewData but you can also use ViewBag
        {
            ViewData["Var1"] = _options.Value.AdminName;
            ViewData["Var2"] = _options.Value.AdminId;
            ViewData["Var3"] = _options.Value.Email;
            return View();
        }
        public IActionResult Index2(DataModel data) // using Model class
        {
            data.AdminName = _options.Value.AdminName;
            data.AdminId = _options.Value.AdminId;
            data.Email = _options.Value.Email;
            return View(data);
        }
        public IActionResult Index3() // passing datas by String concatenation and return Content
        {
            string semicolon = " ; ";
            return Content("Admin name :" + _options.Value.AdminName + semicolon +"Admin ID :" + _options.Value.AdminId.ToString() + semicolon + "Email address : " + _options.Value.Email);
        }
        public IActionResult Index4() // passing datas by StringBuilder and return Content
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Admin name : " + _options.Value.AdminName + "; ");
            builder.Append("Admin ID : " + _options.Value.AdminId + "; ");
            builder.Append("Email address : " + _options.Value.Email);
            return Content(builder.ToString());
        }
        public IActionResult Index5() // passing datas by List<T> generic
        {   
            List<DataModel> data = new List<DataModel>(); 
            data.Add(new DataModel { AdminName = _options.Value.AdminName, AdminId = _options.Value.AdminId , Email = _options.Value.Email});
            return View(data);
        }
    }
}
