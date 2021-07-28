using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var values = adminManager.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
     
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            adminManager.AdminAdd(a);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);

            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin a)
        {
            adminManager.AdminUpdate(a);

            return RedirectToAction("Index");
        }






    }
}