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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelConcat
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            Context context = new Context();

            int id;
            id = 2;
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault() ;
           p = (string)Session["WriterMail"];
            var contentValues = contentManager.GetListByWriter(writeridinfo);
            return View(contentValues);
  
        }
    }
}