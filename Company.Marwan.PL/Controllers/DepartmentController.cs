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

        [HttpGet]
        public IActionResult Details(int? id,string viewname="Details") {

            if (id is null) {

                return BadRequest("Invalid Id");

            }
           var department = _departmentRepository.Get(id.Value);
            if (department is null) { 
            
                return NotFound(new {statuscode =404 , message =$"Department With ID : {id} is not found"});
            
            }
            return View(viewname,department);


        }

        [HttpGet]
        public IActionResult Edit(int? id) {


            return Details(id,"Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken] // With Post Action 
        public IActionResult Edit([FromRoute] int id,Department department)
        {
            if (ModelState.IsValid) {

                if (id != department.Id) return BadRequest(); // 400

                    var count = _departmentRepository.Update(department);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }



                



            }

           
            return View(department);






        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");


        }

        [HttpPost]
        [ValidateAntiForgeryToken] // With Post Action 
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {

                if (id != department.Id) {
                    return BadRequest();
                        
                  } // 400

                var count = _departmentRepository.delete(department);

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }







            }


            return View(department);






        }

    }
}
