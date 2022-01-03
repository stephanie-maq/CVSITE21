using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVSITE21.Data;
using Data.Models;

namespace CVSITE21.Controllers
{
    

    public class ProjectsController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        

        public ActionResult Index(string searchBy, string search)
        {

            using (var context = new ApplicationDbContext())
            {
                var projects = context.Projects.ToList();
                {

                    if (searchBy == "Date" && search != "")
                    {
                        return View(context.Projects.Where(x => x.DateCreated.ToString().ToLower().Contains(search.ToLower().ToString())).ToList());
                    }
                    else if (searchBy == "Name" && search != "")
                    {
                        return View(context.Projects.Where(x => x.Title.ToLower().Contains(search.ToLower().ToString())).ToList());
                    }
                    else { return View(projects); }
                }
            }

        }

        public ActionResult Details(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = context.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DateCreated,ImagePath")] Project project)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    //_httpcontext=System.Web.HttpContext.Current
                    //var username = _httpcontext.User.Identity.Name;
                    var service = System.Web.HttpContext.Current;
                    var username = service.User.Identity.Name;
                    if (!string.IsNullOrEmpty(username))
                    {
                        var user = context.Users.FirstOrDefault(x => x.UserName == username);
                        if (user != null)
                        {
                            project.SavedByUser = user;
                        }
                    }
                    context.Projects.Add(project);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(project);
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = context.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,DateCreated,ImagePath")] Project project)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    context.Entry(project).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(project);
            }
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Project project = context.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }

                return View(project);
            }
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Project project = context.Projects.Find(id);
                context.Projects.Remove(project);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (var context = new ApplicationDbContext())
            {
                if (disposing)
                {
                    context.Dispose();
                }

                base.Dispose(disposing);
            }
        }


    }
}
