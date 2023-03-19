using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class StatisticController : Controller
    {

        public ActionResult Index()
        {
            //ViewBag.categoryCount = _categoryService.GetList().Count();
            //ViewBag.categorySoftware = _categoryService.GetList().Count();
            return View();
        }
    }
}