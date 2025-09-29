using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Models;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Models;
using Company.Marwan.PL.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Marwan.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet] // GET : /Department/Index 
        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid) {
                var employee = new Employee()
                {
                    Name = model.Name,
                    Address = model.Address,
                    Age = model.Age,
                    CreateAt = model.CreateAt,
                    HiringDate = model.HiringDate,
                    Email = model.Email,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    Phone = model.Phone,
                    Salary = model.Salary,


                };
                var count = _employeeRepository.Add(employee);
                if (count > 0) {
                    return RedirectToAction(nameof(Index));
                
                
                }
            
            }
            return View();

        }
        [HttpGet]
       public  IActionResult Details(int? id , string ViewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");

            var employee = _employeeRepository.Get(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee with Id : {id} is not Found " });

            return View(ViewName, employee);



        }

        public IActionResult Edit(int? id) { 
        
            return Details(id,"Edit");
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee model) {

            if (ModelState.IsValid) {

                if (id != model.Id) return BadRequest();
                var count = _employeeRepository.Update(model);
                if (count > 0) {

                    return RedirectToAction(nameof(Index));
                
                
                }
          
            }
            return View(model);


        }




        [HttpGet]
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");


        }

        [HttpPost]
        [ValidateAntiForgeryToken] // With Post Action 
        public IActionResult Delete([FromRoute] int id, Employee model)
        {
            if (ModelState.IsValid)
            {

                if (id != model.Id)
                {
                    return BadRequest();

                } // 400

                var count =_employeeRepository.delete(model);

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }







            }


            return View(model);






        }




























    }
}
