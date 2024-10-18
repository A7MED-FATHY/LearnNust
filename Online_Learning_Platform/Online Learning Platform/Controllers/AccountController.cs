using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Online_Learning_Platform.Models;
using Online_Learning_Platform.ViewModel;
using System.Security.Claims;

namespace Online_Learning_Platform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppliactionUser> userManager;
        private readonly SignInManager<AppliactionUser> signInManager;

        public AccountController(UserManager<AppliactionUser> userManager ,SignInManager<AppliactionUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterUserModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //maping
                AppliactionUser appUser = new AppliactionUser();
                appUser.Address = UserViewModel.Address;
                appUser.UserName = UserViewModel.UserName;
                appUser.Email = UserViewModel.Email;
                appUser.PasswordHash = UserViewModel.Password;
                //save database

                IdentityResult result = await userManager.CreateAsync(appUser, UserViewModel.Password);

                if (result.Succeeded)
                {
                    //cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }


            }
            return View("Register", UserViewModel);





        }

        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> SaveLogin (LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                // check fond

                AppliactionUser appUser =  await userManager.FindByNameAsync(userViewModel.Name);
                if(appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);

                    if (found == true)
                    {

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appUser.Address));
                        await signInManager.SignInWithClaimsAsync(appUser, userViewModel.RememberMe, claims);

                        //await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }



                }
            }
                ModelState.AddModelError("", "User Name or Password Worng");
                //create cookie
            
            return View("Login", userViewModel);
        }







        public async Task <IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }



        //register Admin


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRegisterAdmin(RegisterUserModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //maping
                AppliactionUser appUser = new AppliactionUser();
                appUser.Address = UserViewModel.Address;
                appUser.UserName = UserViewModel.UserName;
                appUser.Email = UserViewModel.Email;
                appUser.PasswordHash = UserViewModel.Password;
                //save database

                IdentityResult result = await userManager.CreateAsync(appUser, UserViewModel.Password);

                if (result.Succeeded)
                {
                 await userManager.AddToRoleAsync(appUser, "Admin");
                    //cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }


            }
            return View("RegisterAdmin", UserViewModel);




        }

        }
    }
