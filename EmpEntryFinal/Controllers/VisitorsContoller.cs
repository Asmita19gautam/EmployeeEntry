using EmpEntryFinal.Data;
using EmpEntryFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpEntryFinal.Controllers
{
    [Authorize]
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VisitorsController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            aaaa();
            var visitorsList = _db.Visitors.ToList();

            return View(visitorsList);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            aaaa();
            var model = new Visitors();

            return View(model);

        }
        

        [HttpPost]
        public IActionResult Add(Visitors visitors)
        {
            aaaa();
            if (ModelState.IsValid)
            {
                _db.Add(visitors);
                _db.SaveChanges();
                //ViewBag.SuccessMessage = visitors.FirstName+" has been added successfully!";
                return RedirectToAction("Index");
            }
            return View(visitors);
        }

        
        [HttpGet]
        public IActionResult Update(int id)
        {
            aaaa();
            var change = _db.Visitors.Find(id);
            return View(change);
        }

        
        [HttpPost]
        public IActionResult Update(Visitors visitors)
        {
            aaaa();
            if (visitors != null)
            {
                _db.Visitors.Update(visitors);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            aaaa();
            var change = _db.Visitors.Find(id);
            return View(change);
        }
        [HttpPost]
        public IActionResult Delete(Visitors visitors)
        {
            aaaa();
            if (visitors != null)
            {
                _db.Visitors.Remove(visitors);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        private void aaaa()
        {
            ViewBag.EmployeeList = _db.Employee.ToList().Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
        }
     
    }
}
