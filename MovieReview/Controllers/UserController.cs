
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Models;
using System.Threading.Tasks;

namespace MovieReview.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        private User Model;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;


        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };

                var result = await userManager.CreateAsync(user, Model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }

            return RedirectToPage("Index");


        }

        public IActionResult Index()
        {
            return View();
        }

        /*
        public async Task<ActionResult> Register(ApplicationUser u)
        {
            var user = new ApplicationUser { UserName = u.UserName, Email = u.Email };

       

           // var result = await UserManager<ApplicationUser>.CreateAsync(user, u.Password);


        }
        */

    }
}
