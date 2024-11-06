using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager manager=new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = manager.GetList();
            return View(files);
        }
    }
}