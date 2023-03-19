using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class AdminCategoryController : Controller
    {

        ICategoryService categoryService = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var values = categoryService.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidatior = new CategoryValidator();
            ValidationResult results = categoryValidatior.Validate(category);

            if (results.IsValid)
            {
                categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = categoryService.GetById(id);
            categoryService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = categoryService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}