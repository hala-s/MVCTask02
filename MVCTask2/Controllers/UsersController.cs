using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVCTask2.Data;
using MVCTask2.Models;
using System.Runtime.InteropServices;

namespace MVCTask2.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDBContext context;

        public UsersController(ApplicationDBContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
        
            return View();

        }
    
    [HttpPost]
    public IActionResult Login(User user)
    {
       var checkUser=context.Users.Where(X=>X.Name==user.Name&&X.Password==user.Password).ToList();
            if (checkUser.Any()) {
                return RedirectToAction(nameof(ActiveAccounts));
            }
            ViewBag.Error = "invalid username/ Password ";

            return View(user);
    }
        public IActionResult GetActiveAccounts()
        {
            var users = context.Users.Where(x => !x.IsActive).ToList();
            return View(users);
        }

        public IActionResult ActiveAccounts(Guid id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.IsActive = true;
            context.SaveChanges();

            return RedirectToAction("GetActiveAccounts");
        }

    }
}
