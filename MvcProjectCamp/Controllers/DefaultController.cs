using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager=new HeadingManager(new EfHeadingDal());
        ContentManager contentManager=new ContentManager(new EfContentDal());
       public ActionResult Heading()
        {
            var headingList=headingManager.GetList();
            return View(headingList);
        }
        public PartialViewResult Index()
        {
            var contentList=contentManager.GetList();
            return PartialView(contentList);
        }
    }
}