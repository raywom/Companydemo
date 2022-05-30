using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CompanyDemo.Abstract;
using CompanyDemo.Data;
using CompanyDemo.Models;
using CompanyDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CompanyDemo.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserProfilesTable _userProfilesTable;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUserProfilesTable userProfilesTable)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._userProfilesTable = userProfilesTable;
            //_roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //IdentityResult result = await _roleManager.CreateAsync(new IdentityRole("buyer"));
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel userRequest)
        {
            IdentityUser user = new IdentityUser
            {
                Email = userRequest.Email,
                UserName = userRequest.Email
            };
            
            var result = await _userManager.CreateAsync(user, userRequest.Password);
            var roleResult = await _userManager.AddToRoleAsync(user, "admin");

            if (result.Succeeded)
            {
                UserProfile userProfile = new UserProfile
                {
                    Email = userRequest.Email,
                    UserId = user.Id
                };
                await _signInManager.SignInAsync(user, false);


                var userProfileCreateResult = await _userProfilesTable.CreateAsync(userProfile);

                if (userProfileCreateResult)
                    return RedirectToAction("Index", "Home");
                else
                    return Problem(
                        "While creating user profile occurred errors. User is created, but you need to update your profile.");
            }
            else
            {
                string details = string.Empty;

                foreach (var error in result.Errors)
                {
                    if (string.IsNullOrEmpty(details))
                        details = error.Description;
                    else
                        details += $" {error.Description}";
                }

                return Problem(details);
            }
        }
        
        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
            }

            return View(model);
        }
        
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
