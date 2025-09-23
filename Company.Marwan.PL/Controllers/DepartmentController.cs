using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Models;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.PL.Dto;
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
        [HttpGet]
        public IActionResult Create() { 
        
        
            return  View();
        
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid) // server side validation
            {
                var department = new Department()
                {
                    code = model.code,
                    name = model.name,
                    CreateAt = model.CreateAt

                };

              var count =  _departmentRepository.Add(department);

                if (count > 0) { 
                    
                    
                        return RedirectToAction(nameof(Index));
                
                
                }
            }

            return View(model);

        }


    }
}
