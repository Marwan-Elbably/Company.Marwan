using Company.Marwan.DAL.Models;
using Company.Marwan.PL.Dto;
using Company.Marwan.PL.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Threading.Tasks;

namespace Company.Marwan.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        #region SignUp

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // P@ssW0rd
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user is null)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);
                    if (user is null)
                    {
                        // Regestier 

                        if (ModelState.IsValid)
                        {
                            user = new AppUser()
                            {
                                UserName = model.UserName,
                                FristName = model.FristName,
                                LastName = model.LastName,
                                Email = model.Email,
                                IsAgree = model.ISAgree,


                            };

                            var result = await _userManager.CreateAsync(user, model.Password);
                            if (result.Succeeded)
                            {

                                return RedirectToAction("SignIn");

                            }

                            foreach (var error in result.Errors)
                            {

                                ModelState.AddModelError("", error.Description);
                            }

                        }




                    }

                }

                ModelState.AddModelError("", "InValid SignUp !!");
            }

            return View();
        }


        #endregion


        #region Signin
        [HttpGet]
        public IActionResult SignIn() { 
        
            return View();
        
        
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null) { 
                        
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (flag)
                    {
                        //SignIn
                      var result =await  _signInManager.PasswordSignInAsync(user,model.Password, model.Rememberme, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
                
                
                }
                ModelState.AddModelError("", "Invalid Login !");


            }



            return View(model);


        }







        #endregion


        #region Signout

        #endregion

        #region forgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordurl(ForgetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
              var user = await _userManager.FindByEmailAsync(model.Email);
                if(user is not null)
                {
                    //Create Token 
                  var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    // Create url
                   var url = Url.Action("ResetPassword", "Account", new {email=model.Email,token},Request.Scheme);
                    // Creage Email
                    var email = new Email()
                    {
                        To = model.Email,
                        Subject = "Reset Password",
                        Body = url
                    };
                    // Send Email 
                  var flag =  EmailSetting.SendEmail(email);
                    if (flag)
                    {
                        // Cheak Your Inbox 
                        return RedirectToAction("CheckYourInbox");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid Reset Password ");
            return View("ForgetPassword",model);
        }
        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();


        }



        #endregion


        // mkkdlmsvlk vwlkl,m ;,dwmklmlwk;  dn vk[l'w d c
    }
}
