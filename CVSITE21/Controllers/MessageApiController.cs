using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CVSITE21.Data;
using Data.Models;

namespace CVSITE21.Controllers
{
    public class MessageApiController : ApiController
    {
        public IHttpActionResult SendMessage(string name, string text, string sender)
        {
            using (var context = new ApplicationDbContext())
            {
                var username = User.Identity.Name;
                var message = new Message()
                {
                    Sender = sender,
                    Receiver = name,
                    Text = text,
                    Read = false,

                };
                var receiver = context.Messages.Where(m => m.Receiver == username);
                context.Messages.Add(message);
                context.SaveChanges();

            }

            return Ok();
        }

        public int GetUnreadMessages()
        {
            string username = User.Identity.Name;
            using (var context = new ApplicationDbContext())
            {
                Profile profile = context.Profiles.Where(u => u.UserId == username).FirstOrDefault();
                int unreadcount = context.Messages.Where(um => um.Read == false && um.Receiver == username).Count();
                return unreadcount;
            }

        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}