using EmpEntryFinal.Data;
using EmpEntryFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EmpEntryFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IActionResult Index()
        {
            ViewBag.EmployeeList = _db.Employee.ToList().Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
            var visitorsList = _db.Visitors.ToList();

            return View(visitorsList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}