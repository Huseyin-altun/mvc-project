using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuesCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem {
                                                   Text=x.CategoryName,
                                                   Value=x.CategoryID.ToString()
                                                   }).ToList();

            List<SelectListItem> valuesWriter = (from x in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.WriterName+""+ x.WriterSurName,
                                                     Value = x.WriterID.ToString()
                                                 }).ToList();
            ViewBag.vlc = valuesCategory;
            ViewBag.vlw = valuesWriter;
            return View();
        }



        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {
         
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                headingManager.HeadingAdd(h);
                return RedirectToAction("Index");
     

            
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

        
            headingManager.HeadingAdd(h);
            return RedirectToAction("Index");



        }


        
        public ActionResult DeleteHeading(int  id)
        {


            var HeadingValue = headingManager.GetByID(id);
            HeadingValue.HeadingStatus = false;
            headingManager.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");



        }
    }
}