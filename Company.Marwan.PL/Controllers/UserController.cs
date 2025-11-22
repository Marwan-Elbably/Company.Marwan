using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Models;
using Company.Marwan.PL.Dto;
using Company.Marwan.PL.Helpers;
using Company.Marwan.PL.Views.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Company.Marwan.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UserController(UserManager<AppUser> userManager, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {

            _userManager = userManager;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }


        [HttpGet] // GET : /Department/Index 
        public async Task<IActionResult> Index(string? SearchInput)
        {
            IEnumerable<UserToReturnDto> users;
            if (string.IsNullOrEmpty(SearchInput))
            {
                users = _userManager.Users.Select(U => new UserToReturnDto()
                {
                    Id = U.Id,
                    UserName = U.UserName,
                    Email = U.Email,
                    FristName = U.FristName,
                    LastName = U.LastName,
                    Roles = _userManager.GetRolesAsync(U).Result

                });

            }
            else
            {
                users = _userManager.Users.Select(U => new UserToReturnDto()
                {
                    Id = U.Id,
                    UserName = U.UserName,
                    Email = U.Email,
                    FristName = U.FristName,
                    LastName = U.LastName,
                    Roles = _userManager.GetRolesAsync(U).Result

                }).Where(U => U.FristName.ToLower().Contains(SearchInput.ToLower()));


            }

            return View("~/Views/user/Index.cshtml", users);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string? id, string ViewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");

            var user = await _userManager.FindByIdAsync(id);

            if (user is null) return NotFound(new { StatusCode = 404, message = $"user with Id : {id} is not Found " });
            var user0 = new UserToReturnDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FristName = user.FristName,
                LastName = user.LastName,
                Roles = _userManager.GetRolesAsync(user).Result
            };



            return View(ViewName, user0);



        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            //{
            //    var departments = await _departmentRepository.GetAllAsync();
            //    ViewData["departments"] = departments;

            //    if (id is null) return BadRequest("Invalid ID");

            //    var employee = await _employeeRepository.GetAsync(id.Value);
            //    if (employee is null) return NotFound(new { StatusCode = 404, message = $"Employee with Id : {id} is not Found " });
            //    var employeeDto = new CreateEmployeeDto()
            //    {

            //        Name = employee.Name,
            //        Address = employee.Address,
            //        Age = employee.Age,
            //        CreateAt = employee.CreateAt,
            //        HiringDate = employee.HiringDate,
            //        Email = employee.Email,
            //        IsActive = employee.IsActive,
            //        IsDeleted = employee.IsDeleted,
            //        Phone = employee.Phone,
            //        Salary = employee.Salary,
            //        DepartmentId = employee.DepartmentID,
            //        ImageName = employee.ImageName,


            //    };

            // return View(employeeDto);
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, UserToReturnDto model)
        {

            if (ModelState.IsValid)
            {



                //var employee = new Employee()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Address = model.Address,
                //    Age = model.Age,
                //    CreateAt = model.CreateAt,
                //    HiringDate = model.HiringDate,
                //    Email = model.Email,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    ImageName = model.ImageName,

                //};

                //// if (id != model.Id) return BadRequest();
                //var count = _employeeRepository.Update(employee);
                //if (count > 0)
                //{

                //    return RedirectToAction(nameof(Index));


                //}
                //if (count > 1000)
                //{
                //    var departments = await _departmentRepository.GetAllAsync();

                //}

                if (id != model.Id) return BadRequest("Invalid Opreations ! ");

                var user = await _userManager.FindByIdAsync(id);
                if (user is null) return BadRequest("Invalid Opreation !");
                user.UserName = model.UserName;
                user.FristName = model.FristName;
                user.LastName = model.LastName;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(model);


        }




        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {

            return await Details(id, "Delete");


        }

        [HttpPost]
        [ValidateAntiForgeryToken] // With Post Action 
        public async Task<IActionResult> Delete([FromRoute] string id, UserToReturnDto model)
        {
            if (ModelState.IsValid)
            {

                //if (id != model.Id)
                //{
                //    return BadRequest();

                //} // 400
                //var employee = new Employee()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Address = model.Address,
                //    Age = model.Age,
                //    CreateAt = model.CreateAt,
                //    HiringDate = model.HiringDate,
                //    Email = model.Email,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    ImageName = model.ImageName,

                //};
                //var count = _employeeRepository.delete(employee);

                //if (count > 0)
                //{
                //    if (model.ImageName is not null)
                //    {
                //        DocumentSetting.DeleteFile(model.ImageName, "Images");
                //    }
                //    return RedirectToAction(nameof(Index));
                //}

                if (id != model.Id) return BadRequest("Invalid Opreations ! ");

                var user = await _userManager.FindByIdAsync(id);
                if (user is null) return BadRequest("Invalid Opreation !");


                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

            }


            return View(model);


        }









    }



}





