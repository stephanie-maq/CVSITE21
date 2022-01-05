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
using Services;

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

        public async Task<ActionResult> Create()
        {
            using (var context = new ApplicationDbContext())
            {
                string userEmail = User.Identity.Name;
                Profile profile = await context.Profiles.FindAsync(userEmail);
                return View(profile);
            }

        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileCreateModel model)
        {
            try
            {

                var service = new ProfileService(System.Web.HttpContext.Current);
                service.SaveNewBook(model);
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


