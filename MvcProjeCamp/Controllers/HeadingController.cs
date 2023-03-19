using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class HeadingController : Controller
    {

        IHeadingService headingService = new HeadingManager(new EfHeadingDal());
        ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
        IWriterService writerService = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var values = headingService.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.categories = category;

            List<SelectListItem> writer = (from x in writerService.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.WriterName + " " + x.WriterSurname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.writers = writer;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            headingService.Add(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var value = headingService.GetById(id);
            value.HeadingStatus = false;
            headingService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var value = headingService.GetById(id);

            List<SelectListItem> category = (from x in categoryService.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.categories = category;

            List<SelectListItem> writer = (from x in writerService.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.WriterName + " " + x.WriterSurname,
                                              Value = x.WriterId.ToString()
                                          }).ToList();
            ViewBag.writers = writer;
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingService.Update(heading);
            return RedirectToAction("Index");
        }
    }
}