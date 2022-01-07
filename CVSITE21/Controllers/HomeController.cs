using CVSITE21.Data;
using Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVSITE21.Controllers
{
    public class HomeController : Controller
    {
        //laddar in startsidan
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                List<Profile> profileslist = context.Profiles.ToList();
                List<Project> projects = context.Projects.ToList();

                //kollar om det finns projekt, om det finns laddar den.
                if (projects.Count() > 0)
                {
                    var project = projects.Last();

                    ViewBag.Projectnamn = "Title: " + project.Title;
                    var projectCreator = project.CreatedBy;
                    var author = context.Profiles.FirstOrDefault(x => x.UserId == projectCreator);

                    if (username == "" && author.IsPrivate == true)
                    {
                        ViewBag.Creator = "Private profile";
                    }
                    else
                    {
                        ViewBag.Creator = author.Fullname;
                    }
                }
                else
                {
                    ViewBag.Projectnamn = "There are currently no projects";
                }
                //Kollar om man är inloggad så att man kan skicka ut CVlista med eller utan gömda användare
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