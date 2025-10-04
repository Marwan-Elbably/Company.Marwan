using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Models;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Models;
using Company.Marwan.PL.Helpers;
using Company.Marwan.PL.Views.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Company.Marwan.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet] // GET : /Department/Index 
        public async Task<IActionResult> Index(string? SearchInput)
        {
            IEnumerable<Employee> employee ;
            if (string.IsNullOrEmpty(SearchInput))
            {
                 employee = await _employeeRepository.GetAllAsync();

            }
            else
            {
                 employee = await _employeeRepository.GetByNameAsync(SearchInput);

            }




            // Dictionary : 
            // ViewDate
           // ViewData["message"] = "Hello From ViewData";
            // ViewBAg
            //TempData

            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Create() {
           var departments = await _departmentRepository.GetAllAsync();
            ViewData["departments"] = departments;
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto model)
        {
            
           
          
            if (ModelState.IsValid) {

                if (model.Image is not null)
                {
                  model.ImageName =  DocumentSetting.UplodeFile(model.Image, "images");

                }
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
                    DepartmentID=model.DepartmentId,
                    ImageName=model.ImageName,


                };
                var count = await _employeeRepository.AddAsync(employee);
                if (count > 0) {
                   // TempData["Message"] = "Employee is Created !!";
                    return RedirectToAction(nameof(Index));
                   
                
                }
               
            }
            return View(model);

        }
        [HttpGet]
       public  async Task<IActionResult> Details(int? id , string ViewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");

            var employee = await _employeeRepository.GetAsync(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee with Id : {id} is not Found " });

            return View(ViewName, employee);



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) {
            var departments =await _departmentRepository.GetAllAsync();
            ViewData["departments"] = departments;

            if (id is null) return BadRequest("Invalid ID");

            var employee =await _employeeRepository.GetAsync(id.Value);
            if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee with Id : {id} is not Found " });
            var employeeDto = new CreateEmployeeDto()
            {
                
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                CreateAt = employee.CreateAt,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                IsActive = employee.IsActive,
                IsDeleted = employee.IsDeleted,
                Phone = employee.Phone,
                Salary = employee.Salary,
                DepartmentId=employee.DepartmentID,
                ImageName = employee.ImageName,
                

            };

            return View(employeeDto);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, CreateEmployeeDto model) {

            if (ModelState.IsValid) {

                if (model.ImageName is not null && model.Image is not null) {

                    DocumentSetting.DeleteFile(model.ImageName, "Images");
                
                }
                if(model.Image is not null)
                {
                    model.ImageName =  DocumentSetting.UplodeFile(model.Image, "Images");
                }

                var employee = new Employee()
                {
                    Id = model.Id,
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
                    ImageName = model.ImageName,

                };
                // if (id != model.Id) return BadRequest();
                var count = _employeeRepository.Update(employee);
                if (count > 0) {

                    return RedirectToAction(nameof(Index));
                
                
                }
                if (count > 1000)
                {
                     var departments =await _departmentRepository.GetAllAsync();

                }

            }
            return View(model);


        }




        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            return await Details(id, "Delete");


        }

        [HttpPost]
        [ValidateAntiForgeryToken] // With Post Action 
        public IActionResult Delete([FromRoute] int id, CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {

                if (id != model.Id)
                {
                    return BadRequest();

                } // 400
                var employee = new Employee()
                {
                    Id = model.Id,
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
                    ImageName = model.ImageName,

                };
                var count =_employeeRepository.delete(employee);

                if (count > 0)
                {
                    if (model.ImageName is not null)
                    {
                        DocumentSetting.DeleteFile(model.ImageName, "Images");
                    }
                    return RedirectToAction(nameof(Index));
                }







            }


            return View(model);






        }




























    }
}
