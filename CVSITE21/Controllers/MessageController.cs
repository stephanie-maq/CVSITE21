using CVSITE21.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var userMessages = context.Messages.Where(mes => mes.Recipient == username).ToList();
                return View(userMessages);
            }

        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        [HttpGet]
        public async Task<ActionResult> Create(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                
                string sender = null;
                var username = User.Identity.Name;
                Profile senderprofile = await context.Profiles.FindAsync(username);

                if(senderprofile != null)
                {
                    sender = senderprofile.Fullname.ToString();
                }

                Profile profile = await context.Profiles.FindAsync(userId);
                return View(new SendMessageViewModel { Profile = profile, Sender = sender});
            }
        }

        [HttpGet]
        public async Task<ActionResult> MarkAsRead(int messageId)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var dbMessage = await context.Messages.FindAsync(messageId);
                dbMessage.isRead = true;
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
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
