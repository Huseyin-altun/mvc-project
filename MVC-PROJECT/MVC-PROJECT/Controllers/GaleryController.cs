using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageManager ımageManager = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {

            var Values=ımageManager.GetList();
            return View(Values);
        }
    }
}