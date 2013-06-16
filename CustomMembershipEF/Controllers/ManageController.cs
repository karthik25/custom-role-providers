using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using CustomMembershipEF.Contexts;
using CustomMembershipEF.Entities;

namespace CustomMembershipEF.Controllers
{
    public class ManageController : Controller
    {
        private readonly UsersContext _usersContext;

        public ManageController()
        {
            _usersContext = new UsersContext();
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            return View(_usersContext.Users.Where(u => u.UserId > 1).ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        public JsonResult UpdateRole(int userId, short roleId)
        {
            _usersContext.AddUserRole(new UserRole{ UserId = userId, RoleId = roleId});
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

    public static class ListProvider
    {
        public static List<SelectListItem> Roles = new List<SelectListItem>
                                                   {
                                                       new SelectListItem { Text = "Super Admin", Value = "0" },
                                                       new SelectListItem { Text = "Admin", Value = "1" },
                                                       new SelectListItem { Text = "Author", Value = "2" }
                                                   };

        public static List<SelectListItem> GetRoles(short roleId)
        {
            Roles.ForEach(r => r.Selected = false);
            var role = Roles.Single(r => r.Value == roleId.ToString(CultureInfo.InvariantCulture));
            role.Selected = true;
            return Roles;
        }
    }
}
