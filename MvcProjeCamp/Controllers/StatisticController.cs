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
    public class StatisticController : Controller
    {

        ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
        IHeadingService headingService = new HeadingManager(new EfHeadingDal());
        IWriterService writerService = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            ViewBag.categoryCount = categoryService.GetList().Count();
            ViewBag.headingSofware = headingService.GetList().Where(x => x.Category.CategoryName == "Yazılım").Count();
            ViewBag.writerWithA = writerService.GetList().Where(x => x.WriterName.ToUpper().Contains("A")).Count();
            var categoryStatusTrue = categoryService.GetList().Where(x => x.CategoryStatus == true).Count();
            var categoryStatusFalse = categoryService.GetList().Where(x => x.CategoryStatus == false).Count();
            ViewBag.categoryStatus = categoryStatusTrue - categoryStatusFalse;
            return View();
        }
    }
}