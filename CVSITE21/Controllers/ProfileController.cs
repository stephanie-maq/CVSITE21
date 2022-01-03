using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CVSITE21.Data;
using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shared;

namespace CVSITE21.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public async Task<ActionResult> Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var profils = await context.Profiles.FindAsync(User.Identity.GetUserId());
                return View(profils);
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileCreateModel model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var newProfile = new Profile()
                    {
                        Fullname = model.Fullname,
                        Address = model.Address,
                        Age = model.Age
                    };

                    var filename = model.ImagePath.FileName;
                    var filepath = Server.MapPath("~/images");
                    model.ImagePath.SaveAs(filepath + "/" + filename);

                    newProfile.ImagePath = filename;

                    context.Profiles.Add(newProfile);
                    context.SaveChanges();
                };
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
