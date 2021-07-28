using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class ConcatController : Controller
    {
        // GET: Concat

        ConcatManager concatManager = new ConcatManager(new EfConcatDal());
        public ActionResult Index()
        {
            var concatValues = concatManager.GetList();
            return View(concatValues);
        }

        public ActionResult GetConcatDetails(int id)
        {
            var concatValues = concatManager.GetByID(id);
            return View(concatValues);
        }

        public PartialViewResult MessageListMenu()
        {

            return PartialView();

        }


    }
}