using System.Web.Mvc;
using CustomMembershipEF.Models;

namespace CustomMembershipEF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult Protected()
        {
            var user = (UserIdentity) User.Identity;
            return View((object)user.UserId);
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult SuperAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize]
        public ActionResult AdminOrSuperAdmin()
        {
            if (!User.IsInRole("SuperAdmin") && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [Authorize(Roles = "Admin, Author")]
        public ActionResult AdminOrAuthor()
        {
            return View();
        }
        
        [Authorize(Users = "karthik,testuser")]
        public ActionResult SelectedUsersOnly()
        {
            return View();
        }
    }
}
