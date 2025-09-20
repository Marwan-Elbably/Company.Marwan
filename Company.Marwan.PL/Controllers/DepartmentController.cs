using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Reposatires;
using Microsoft.AspNetCore.Mvc;

namespace Company.Marwan.PL.Controllers
{     // MVC controller
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;


       public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository =  departmentRepository;
        }
        [HttpGet] // GEt : /Department/Index 
        public IActionResult Index()
        {
            
           var departments= _departmentRepository.GetAll();
            return View(departments);
        }
    }
}
