using Company.Marwan.BLL.Interfaces;
using Company.Marwan.DAL.Models;
using Company.Marwan.PL.Dto;
using Company.Marwan.PL.Helpers;
using Company.Marwan.PL.Views.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Threading.Tasks;

namespace Company.Marwan.PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository , UserManager<AppUser> userManager)
        {

            _roleManager = roleManager;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _userManager = userManager;
        }


        [HttpGet] // GET : /Department/Index 
        public async Task<IActionResult> Index(string? SearchInput)
        {
            IEnumerable<RoleToReturnDto> roles;
            if (string.IsNullOrEmpty(SearchInput))
            {
                roles = _roleManager.Roles.Select(U => new RoleToReturnDto()
                {
                    Id = U.Id,
                    Name = U.Name,
                 

                });

            }
            else
            {
                roles = _roleManager.Roles.Select(U => new RoleToReturnDto()
                {
                    Id = U.Id,
                    Name = U.Name,


                }).Where(R=>R.Name.ToLower().Contains(SearchInput.ToLower()));


            }

            return View("~/Views/Role/Index.cshtml", roles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleToReturnDto model)
        {


            if (ModelState.IsValid)
            {
              var role = await _roleManager.FindByNameAsync(model.Name);
                if(role is null)
                {
                    role= new IdentityRole()
                    {
                        Name = model.Name
                    };
                  var result =  await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
                
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id, string ViewName = "Details")
        {
            if (id is null) return BadRequest("Invalid ID");

            var role = await _roleManager.FindByIdAsync(id);

            if (role is null) return NotFound(new { StatusCode = 404, message = $"role with Id : {id} is not Found " });
            var dto = new RoleToReturnDto()
            {
                Id = role.Id,
                Name = role.Name,
              
            };



            return View(ViewName, dto);



        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, RoleToReturnDto model)
        {

            if (ModelState.IsValid)
            {



                if (id != model.Id) return BadRequest("Invalid Opreations ! ");

                var role = await _roleManager.FindByIdAsync(id);
                if (role is null) return BadRequest("Invalid Opreation !");
               
             var roleResult = await _roleManager.FindByNameAsync(model.Name);
               if(roleResult is not null)
                {
                    role.Name = model.Name;
                   

                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }

                ModelState.AddModelError("", "Invalid Opreation !");

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
        public async Task<IActionResult> Delete([FromRoute] string id, RoleToReturnDto model)
        {
            if (ModelState.IsValid)
            {



                if (id != model.Id) return BadRequest("Invalid Opreations ! ");

                var role = await _roleManager.FindByIdAsync(id);
                if (role is null) return BadRequest("Invalid Opreation !");

                
                    


                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                

                ModelState.AddModelError("", "Invalid Opreation !");

            }
            return View(model);


        }


        [HttpGet]
        public async Task<IActionResult> AddOrRemoveUser(string roleId)
        {
            
            var role= await _roleManager.FindByIdAsync(roleId);
            if (role is null) return NotFound();

            ViewData["RoleId"] = roleId;


            var usersInRole = new List<UsersInroleViewModel>();
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users) {

                var userInRole = new UsersInroleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,


                };
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userInRole.IsSelected = true;
                }else
                {
                    userInRole.IsSelected = false;

                }

                usersInRole.Add(userInRole);


            }


            return View(usersInRole);

        }



        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUser(string roleId,List<UsersInroleViewModel> users)
        {

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null) return NotFound();

            if (ModelState.IsValid) 
            {
                foreach (var user in users)
                {
                    var appuser = await _userManager.FindByIdAsync(user.UserId);
                    if (appuser is not null) {

                        if (user.IsSelected && ! await _userManager.IsInRoleAsync(appuser, role.Name))
                        {
                           await _userManager.AddToRoleAsync(appuser,role.Name);

                        }else if (! user.IsSelected && await _userManager.IsInRoleAsync(appuser, role.Name))
                        {
                           await _userManager.RemoveFromRoleAsync(appuser,role.Name);
                        }


                    }
                

                }

                return RedirectToAction(nameof(Edit), new {id = roleId});
            
            
            }

            return View(users);


        }


    }
}
