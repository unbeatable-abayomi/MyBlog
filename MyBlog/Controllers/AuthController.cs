using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.ViewModels;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
	public class AuthController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel vm)
        {
         var result =  await  _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
          // _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false).GetAwaiter().GetResult();
            return RedirectToAction("Index","Panel");
        }

        [HttpGet]
        public async Task <IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
         return RedirectToAction("Index", "Home");
        }
    }
}
