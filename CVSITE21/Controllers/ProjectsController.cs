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
using Microsoft.AspNet.Identity;

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
                //Hämtar Id från context för att kontrollera om besökaren är inloggad.
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                if (username != "")
                {
                    ViewBag.ProfileId = username;

                    var ProjectIdWhereProfileIdIsCurrent = context.ProfileInProject.Where(x => x.ProfileId == username).ToList();
                    List<string> ListOfProjectIDs = new List<string>();
                    foreach (var item in ProjectIdWhereProfileIdIsCurrent)
                    {
                        ListOfProjectIDs.Add(item.ProjectID.ToString());
                    }
                    ViewBag.Projects = ListOfProjectIDs;
                }
                //Skapar två listor en som används för att gå igenom samtliga projekt och lägga in data i den temporära modellen/klassen och en som visar upp datan i viewen från den temporära klassen/modellen.
                List<Project> allProjects = new List<Project>();
                List<ProjectWithProfilesForList> ProjectsForIndexList = new List<ProjectWithProfilesForList>();
                allProjects = context.Projects.Include(x => x.ActiveUsers).ToList();

                foreach (var item in allProjects)
                {
                    ProjectWithProfilesForList ProjectWithProfilesForList = null;
                    
                    ProjectWithProfilesForList = new ProjectWithProfilesForList(item.Id, item.Title, item.CreatedBy, item.Description, item.DateCreated);
                    
                    
                    var activeUsers = context.ProfileInProject.Where(x => x.ProjectID == item.Id).ToList();
                    List<string> HiddenProfiles = new List<string>();
                    List<string> NormalProfiles = new List<string>();

                    //Lägger in i två listor, en med alla och en med bara de som inte är private.
                    foreach (var ProfileInProject in activeUsers)
                    {
                        var profilesinproject = context.Profiles.Where(x => x.UserId == ProfileInProject.ProfileId).ToList();

                        foreach (var userProfile in profilesinproject)
                        {
                            HiddenProfiles.Add(userProfile.UserId);
                            if (userProfile.IsPrivate == false)
                            {
                                NormalProfiles.Add(userProfile.UserId);
                            }
                        }
                    }
                    ProjectWithProfilesForList.ListOfHiddenProfiles = HiddenProfiles;
                    ProjectWithProfilesForList.ListOfNormalProfiles = NormalProfiles;

                    ProjectsForIndexList.Add(ProjectWithProfilesForList);
                }

                

                //Sql querys för att få till sökfunktionen på datum eller namn
                {
                    if (searchBy == "Date" && search != "")
                    {
                        return View(ProjectsForIndexList.Where(x => x.DateCreated.ToString().ToLower().Contains(search.ToLower().ToString())).ToList());
                    }
                    else if (searchBy == "Name" && search != "")
                    {
                        return View(ProjectsForIndexList.Where(x => x.Title.ToLower().Contains(search.ToLower().ToString())).ToList());
                    }
                    else { return View(ProjectsForIndexList); }
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
        [Authorize]
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
                    string username = User.Identity.GetUserName();
                    context.Projects.Add(project);
                    project.CreatedBy = username;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(project);
            }
        }

        public ActionResult AddToProfileInProject(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                string username = System.Web.HttpContext.Current.User.Identity.Name;

                context.ProfileInProject.Add(new ProfileInProject { ProjectID = id, ProfileId = username });
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult RemoveFromProfileInProject(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                string username = System.Web.HttpContext.Current.User.Identity.Name;

                var wantedProject = context.ProfileInProject.Where(x => x.ProjectID == id && x.ProfileId == username).FirstOrDefault(); ;

                context.ProfileInProject.Remove(wantedProject);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            using (var context = new ApplicationDbContext())
            {
                var username = System.Web.HttpContext.Current.User.Identity.Name;
                if (!string.IsNullOrEmpty(username))
                {
                    var projectet = context.Projects.FirstOrDefault(x => x.Id == id);
                    if (projectet.CreatedBy == username)
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
                 return Redirect("~/Projects"); 
            }
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CreatedBy,Description,DateCreated,ImagePath")] Project project)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    context.Entry(project).State = EntityState.Modified;
                    string username = User.Identity.GetUserName();
                    project.CreatedBy = username;
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
