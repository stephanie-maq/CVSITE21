using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVSITE21.Data;
using Data.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Logging;
using System.Net;

namespace CVSITE21.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public async Task<ActionResult> Index()
        {
            using (var context = new ApplicationDbContext())
            {
                Profile profile = await context.Profiles.FindAsync(User.Identity.Name);
                return View(profile);
            }

        }

        
        public ActionResult List(string search)
        {

            using (var context = new ApplicationDbContext())
            {
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                if (username != null && username != "") { 
                    var profiles = context.Profiles.ToList();
                    {

                        if (search != null && search != "")
                        {
                            return View(context.Profiles.Where(x => x.Fullname != null).Where(x => x.Fullname.ToString().ToLower().Contains(search.ToLower().ToString())).ToList());
                        }
                        if (search == "") { return View(profiles.Where(x => x.Fullname != null)); }
                        else { return View(profiles.Where(x => x.Fullname != null)); }
                    
                    }
                }
                else {
                    var profiles = context.Profiles.ToList();
                    {

                        if (search != null && search != "")
                        {
                            return View(context.Profiles.Where(x => x.Fullname != null).Where(x => x.IsPrivate.Equals(false)).Where( x => x.Fullname.ToString().ToLower().Contains(search.ToLower().ToString())).ToList());
                        }
                        if (search == "") { return View(profiles.Where(x => x.Fullname != null).Where(x => x.IsPrivate.Equals(false))); }
                        else { return View(profiles.Where(x => x.IsPrivate.Equals(false))); }

                    }
                }
            }

        }



        public ActionResult Details(string UserId)
        {
            using (var context = new ApplicationDbContext())
            {
                if (UserId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var encodedId = "";
                Profile profile = context.Profiles.Find(UserId);
                if (profile == null)
                {
                    return HttpNotFound();
                }

                return View(profile);
            }
        }

        public async Task<ActionResult> Create()
        {
            using (var context = new ApplicationDbContext())
            {
                string userEmail = User.Identity.GetUserName();
                Profile profile = await context.Profiles.FindAsync(userEmail);
                return View(profile);
            }

        }

        // POST: Profile/Create
        [HttpPost]
        public async Task<ActionResult> Create(Profile model)
        {
            try
            {

                using (var context = new ApplicationDbContext())
                {

                    Profile profile = await context.Profiles.FindAsync(User.Identity.Name);
                    profile.WorkExperiences = model.WorkExperiences;
                    profile.Age = model.Age;
                    profile.Address = model.Address;
                    profile.Fullname = model.Fullname;
                    profile.Email = model.Email;
                    profile.AcademicExperiences = model.AcademicExperiences;
                    profile.ImagePath = model.ImagePath;
                    profile.Skills = model.Skills;
                    profile.IsPrivate = model.IsPrivate;

                    await context.SaveChangesAsync();
                };

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
