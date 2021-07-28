using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();
        public ActionResult Index()
        {

            var writerValues = writerManager.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {

            ValidationResult result = validationRules.Validate(w);
            if (result.IsValid)
            {
                writerManager.WriterAdd(w);
                return RedirectToAction("Index");
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



        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {

            var writerValue = writerManager.GetById(id);  

            return View(writerValue);
        }


        [HttpPost]
        public ActionResult UpdateWriter(Writer w)
        {

            ValidationResult result = validationRules.Validate(w);
            if (result.IsValid)
            {
                writerManager.WriteUpdate(w);
                return RedirectToAction("Index");
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


    }
}