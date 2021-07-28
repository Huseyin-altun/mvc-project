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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles="B")]
        public ActionResult Index()
        {

            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

          [HttpGet]
        public ActionResult AddCategory()
        {

       
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidation categoryValidator = new CategoryValidation();
            ValidationResult result = categoryValidator.Validate(c);
            if (result.IsValid)
            {
                categoryManager.CategoryAdd(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors )
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            
            return View();
        }


        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet] 
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = categoryManager.GetByID(id);
         
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            categoryManager.CategoryUpdate(c);

            return RedirectToAction("Index");
        }




    }
}