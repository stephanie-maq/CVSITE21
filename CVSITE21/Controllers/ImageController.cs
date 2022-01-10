
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
using System.Net.Http;

namespace CVSITE21.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }


        // GET: Image/Create
        public ActionResult Create()
        {
            
            using (var context = new ApplicationDbContext())
            {
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                var user = context.Profiles.First(a => a.Email == username);
                if (user.Fullname == null)
                {
                    return Redirect("~/Profile/create");
                }
                else
                {
                    return View();
                }

            }
        }

        // POST: Image/Create
        [HttpPost]
        public ActionResult Create(SaveImage model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    
                    
                   
                    var newImg = new SaveImage()
                    { };

                    var filename = model.Image.FileName;
                    var filepath = System.Web.HttpContext.Current.Server.MapPath("~/Images");
                    model.Image.SaveAs(filepath + "/" + filename);

                    newImg.ImagePath = filename;
                    var filenameraw = filename.ToString();
                    var username = System.Web.HttpContext.Current.User.Identity.Name;
                    var user = context.Profiles.First(a => a.Email == username);



                    user.ImagePath = filenameraw;
                    context.SaveChanges();
                    
                }

                return Redirect("~/Profile");
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
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

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
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
