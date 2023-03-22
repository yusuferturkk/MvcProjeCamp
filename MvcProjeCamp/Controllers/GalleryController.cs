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
    public class GalleryController : Controller
    {
        
        IImageFileService imageFileService = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var values = imageFileService.GetList();
            return View(values);
        }
    }
}