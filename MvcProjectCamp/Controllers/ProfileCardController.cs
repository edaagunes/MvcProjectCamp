using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ProfileCardController : Controller
    {
        ProfileManager manager=new ProfileManager(new EfProfileDal());
        public ActionResult Index()
        {
			var values = manager.GetList();
			return View(values);
		}
    }
}