using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class ContentController : Controller
    {

        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListById(id);
            return View(contentValues);
        }
        

        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
          
            return View(values);
        }

    }
}