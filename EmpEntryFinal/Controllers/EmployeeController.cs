using AspNetCoreHero.ToastNotification.Abstractions;
using EmpEntryFinal.Data;
using EmpEntryFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.UI;
//using System.Web.Extensions;
namespace EmpEntryFinal.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        public INotyfService _notifyService { get; }
        
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext, INotyfService notifyService)
        {
            _dbContext = dbContext;
            _notifyService = notifyService;

        }
        [AllowAnonymous]
        public IActionResult Index()
        
        {
            var employeeList = _dbContext.Employee.ToList();
            return View(employeeList);
        }
        public List<Department> GetList()
        {
            return _dbContext.Department.ToList();
        }
        public List<Designation> Get()
        {
            return _dbContext.Designation.ToList();
        }
        
        [HttpGet]
        public IActionResult Add()
        {

            listOfDep();
            listOfDesignation();
            var model = new Employee();

            return View(model);

        }
        
        [HttpPost]
        public IActionResult Add(Employee employee)
        {

            listOfDep();
            listOfDesignation();
            if (ModelState.IsValid)
            {
                var filePic = employee.ProfilePic;

                if (filePic != null)
                {
                    var storePath = $"Images/{filePic.FileName}";

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", storePath);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        filePic.CopyTo(stream);
                    }
                    employee.ProfilePath = "/" + storePath;
                }


                _dbContext.Add(employee);
                _dbContext.SaveChanges();

                //string message = "Your details have been saved successfully.";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "')};";
                //ScriptManager.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                return RedirectToAction("Index");
            }
             return View(employee);
            
        }

        
        [HttpGet]
        public IActionResult Update(int id, int departmentId, int designationId)
        {

            listOfDep();
            listOfDesignation();

            var change = _dbContext.Employee.Find(id);
            return View(change);
        }

       
        [HttpPost]
        public IActionResult Update(Employee employee)
        {

            try
            {
                if (employee != null)
                {
                    var filePic = employee.ProfilePic;

                    if (filePic != null)
                    {
                        var storePath = $"Images/{filePic.FileName}";

                        var path = Path.Combine(
                          Directory.GetCurrentDirectory(), "wwwroot/Images",
                          filePic.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            filePic.CopyTo(stream);
                        }
                        employee.ProfilePath = "/" + storePath;
                    }
                    
                    listOfDep();
                    listOfDesignation();

                    _dbContext.Employee.Update(employee);
                    _dbContext.SaveChanges();
                    _notifyService.Success("This is a Success Notification");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _notifyService.Error("This is an Error Notification. "+ex.Message);
                return View(employee);
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            listOfDep();
            listOfDesignation();
            var change = _dbContext.Employee.Find(id);
            return View(change);
        }
    
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            listOfDep();
            listOfDesignation();
            _dbContext.Employee.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        private void listOfDep()
        {

            ViewBag.DepartmentList = GetList().Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.DepartmentName,
                Selected = true
            }).ToList();  
        }
        private void listOfDesignation()
        {
            ViewBag.DesignationList = Get().Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Post,
                Selected = true
            }).ToList();
        }
        public IActionResult Search(string SearchTerm)
        {
            @ViewData["CurrentFilter"]=SearchTerm;
            var employee = from e in _dbContext.Employee
                                    select e;
            if (!String.IsNullOrEmpty(SearchTerm))
            {
                employee = employee.Where(e => e.Name.Contains(SearchTerm));
                var emp = employee.ToList();                       
            }
            return View("index", employee.ToList());
        }
    }
}
