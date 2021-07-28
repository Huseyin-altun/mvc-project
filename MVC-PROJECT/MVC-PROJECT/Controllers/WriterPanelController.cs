using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace projectMVC.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            Context context = new Context();
            string   p = (string)Session["WriterMail"];
            ViewBag.QW = p;
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writetValue = writerManager.GetById(id);
            return View(writetValue);
     
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            ValidationResult result = validationRules.Validate(w);
            if (result.IsValid)
            {
                writerManager.WriteUpdate(w);
                return RedirectToAction("AllHeading","WriterPanel");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();

        }

        public ActionResult MyHeading(string p)
        {
            Context context = new Context();
            p = (string)Session["WriterMail"];
         var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuesCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlc = valuesCategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading h )
        {
            Context context = new Context();
           string  writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterID = writeridinfo;
            h.HeadingStatus = true;
            headingManager.HeadingAdd(h);
            return RedirectToAction("MyHeading");
           
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuesCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.vlc = valuesCategory;


            var headingValue = headingManager.GetByID(id);
            return View(headingValue);


        }
        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {


            headingManager.HeadingUpdate(h);
            return RedirectToAction("MyHeading");



        }


        public ActionResult DeleteHeading(int id)
        {


            var HeadingValue = headingManager.GetByID(id);
            HeadingValue.HeadingStatus = false;
            headingManager.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");



        }

        public ActionResult AllHeading(int page=1)
        {

            var heading = headingManager.GetList().ToPagedList(page, 4);
            return View(heading);


        }




    }
}