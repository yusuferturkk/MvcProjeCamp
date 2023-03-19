using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class WriterController : Controller
    {

        IWriterService writerService = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var values = writerService.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult results = validator.Validate(writer);

            if (results.IsValid)
            {
                writerService.Add(writer);
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

        public ActionResult DeleteWriter(int id)
        {
            var value = writerService.GetById(id);
            writerService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var value = writerService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            writerService.Update(writer);
            return RedirectToAction("Index");
        }
    }
}