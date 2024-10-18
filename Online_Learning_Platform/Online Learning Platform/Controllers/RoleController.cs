﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.ViewModel;

namespace Online_Learning_Platform.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
         {
            this.roleManager = roleManager;
        }

        public IActionResult AddRole(RoleViewModel roleViewModel)
        {
            return View("AddRole");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded == true)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole", roleViewModel);
        }
    }
}