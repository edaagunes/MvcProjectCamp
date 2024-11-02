using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            var headingValues = manager.GetList();
            return View(headingValues);
        }
    }
}