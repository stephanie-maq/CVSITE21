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
            using (var context = new ApplicationDbContext())
            {

                return View();
            }
        }

        public ActionResult MarkAsRead(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                Message message = context.Messages.Where(um => um.Id.ToString() == username).FirstOrDefault();
                message.Read = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        // POST: Message/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Text,Sender,Receiver")] Message message)
        {
            using (var context = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    context.Messages.Add(message);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
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
