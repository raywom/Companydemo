// using System.Security.Claims;
// using CompanyDemo.Data;
// using CompanyDemo.Models;
// using CompanyDemo.Stores;
// using CompanyDemo.Tables;
// using CompanyDemo.ViewModels;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
//
// namespace CompanyDemo.Controllers
// {
//     public class RolesController : Controller
//     {
//         readonly UserManager<ClaimsPrincipal> _userManager;
//         readonly RoleManager<ExtendedIdentityRole> _roleManager;
//         readonly ApplicationDbContext _context;
//         public RolesController(RoleManager<ExtendedIdentityRole> roleManager, ApplicationDbContext dbContext, UserManager<ClaimsPrincipal> userStore)
//         {
//             _roleManager = roleManager;
//             _context = dbContext;
//             _userManager = userStore;
//         }
//         
//         public IActionResult Index()
//         {
//             _userManager.AddToRoleAsync(User, "Admin");
//             return View();
//         }
//         
//         public IActionResult Create()
//         {
//             return View();
//         }
//         
//         [HttpPost]
//         public async Task<IActionResult> Create(ExtendedIdentityRole role)
//         {
//             if (ModelState.IsValid)
//             {
//                 var result = await _roleManager.CreateAsync(role);
//                 if (result.Succeeded)
//                 {
//                     return RedirectToAction("Index");
//                 }
//                 else
//                 {
//                     foreach (var error in result.Errors)
//                     {
//                         ModelState.AddModelError(string.Empty, error.Description);
//                     }
//                 }
//             }
//             return View(role);
//         }
//         
//         public async Task<IActionResult> Update(string id)
//         {
//             var role = await _roleManager.FindByIdAsync(id);
//             if (role == null)
//             {
//                 return RedirectToAction("Index");
//             }
//             return View(role);
//         }
//         
//         [HttpPost]
//         public async Task<IActionResult> Update(ExtendedIdentityRole role)
//         {
//             if (ModelState.IsValid)
//             {
//                 var result = await _roleManager.UpdateAsync(role);
//                 if (result.Succeeded)
//                 {
//                     return RedirectToAction("Index");
//                 }
//                 else
//                 {
//                     foreach (var error in result.Errors)
//                     {
//                         ModelState.AddModelError(string.Empty, error.Description);
//                     }
//                 }
//             }
//             return View(role);
//         }
//         
//         public async Task<IActionResult> Delete(string id)
//         {
//             var role = await _roleManager.FindByIdAsync(id);
//             if (role == null)
//             {
//                 return RedirectToAction("Index");
//             }
//             return View(role);
//         }
//         
//         [HttpPost]
//         public async Task<IActionResult> Delete(ExtendedIdentityRole role)
//         {
//             var result = await _roleManager.DeleteAsync(role);
//             if (result.Succeeded)
//             {
//                 return RedirectToAction("Index");
//             }
//             else
//             {
//                 foreach (var error in result.Errors)
//                 {
//                     ModelState.AddModelError(string.Empty, error.Description);
//                 }
//             }
//             return View(role);
//         }
//         
//         
//     }
// }
