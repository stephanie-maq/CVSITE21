using CVSITE21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVSITE21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                if (username != "")
                {
                    var profiles = context.Profiles.ToList();
                    {
                        return View(context.Profiles.Where(x => x.Fullname != null).ToList());
                    }
                }
                else
                {
                    var profiles = context.Profiles.ToList();
                    {
                        return View(profiles.Where(x => x.Fullname != null).Where(x => x.IsPrivate.Equals(false)).Take(3));

                    }
                }
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Route("home/projects")]
        public ActionResult Projects()
        {
            ViewBag.Message = "Projects to display.";

            return View();
        }


    }
}