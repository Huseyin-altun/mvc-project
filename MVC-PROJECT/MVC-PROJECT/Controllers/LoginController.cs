using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projectMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var adminuserinfo = adminManager.GetAdmin(a.AdminUserName, a.AdminPassword);
            if (adminuserinfo!=null)
            {

                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else{
                return RedirectToAction("Index");

            }

        }




        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer w)
        {
            var writeruserinfo = writerLoginManager.GetWriter(w.WriterMail,w.WriterPassword);
            if (writeruserinfo != null)
            { 
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");

            }

        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");

        }





    }
}