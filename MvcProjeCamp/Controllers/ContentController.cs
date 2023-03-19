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
    public class ContentController : Controller
    {

        IContentService contentService = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var values = contentService.GetListByContentId(id);
            return View(values);
        }

        public ActionResult ContentWritten(int id)
        {
            var values = contentService.GetListByWriterId(id);
            return View(values);
        }
    }
}