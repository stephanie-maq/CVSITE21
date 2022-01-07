using CVSITE21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVSITE21.Models;
using Data.Models;

namespace CVSITE21.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var username = User.Identity.Name;
                var message = new Message()
                {
                    Sender = "gabriel@gmail.com",
                    Receiver = "step@gmail.com",
                    Text = "Hi",
                    Read = false
                };

                var result = context.Messages.Where(mes => mes.Receiver == username).ToList();
                context.Messages.Add(message);
                context.SaveChanges();
                return View(result);
            }

        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Createe()
        {
            return View();
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Message/Delete/5
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
