using System;
using System.Threading.Tasks;
using BethenysPieShop.Auth;
using BethenysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BethenysPieShop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult UserManagement()
        {
            var users = userManager.Users;
            return View(users);
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(addUserViewModel);
            }
            var user = new ApplicationUser
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
                BirthDate = addUserViewModel.BirthDate,
                City = addUserViewModel.City,
                Country = addUserViewModel.Country

            };
            var result = await userManager.CreateAsync(user,addUserViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", userManager.Users);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addUserViewModel);
        }
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return RedirectToAction("UserManagement");
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string UserName, string Email, DateTime BirthDate,string City, string Country)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.UserName = UserName;
                user.Email = Email;
                user.BirthDate = BirthDate;
                user.City = City;
                user.Country = Country;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                ModelState.AddModelError("", "Error occured while updating the user");
                return View(user);
            }
            else
            {
                return RedirectToAction("UserManagement");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userid)
        {
            var user = await userManager.FindByIdAsync(userid);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                ModelState.AddModelError("", "Error occured while deleting the user");
            }
            else
            {
                ModelState.AddModelError("", "The user could not be found");
            }
            return View("UserManagement", userManager.Users);
        }
    }
}
