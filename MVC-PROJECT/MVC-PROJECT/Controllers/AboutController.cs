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
    public class AboutController : Controller
    {
        // GET: About

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }


        [HttpGet]
        public ActionResult AddAbout()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About a    )
        {

            aboutManager.AboutAdd(a);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }
    }
}