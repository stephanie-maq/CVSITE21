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
        [HttpPost]
        [Route("api/messages/{sender}/{receiver}/{text}")]
        public IHttpActionResult SendMessage(string sender, string receiver, string text)
        {
            using (var context = new ApplicationDbContext())
            {
                var message = new Message
                {
                    Sender = sender,
                    Recipient = receiver,
                    Text = text,
                    isRead = false
                };
                context.Messages.Add(message);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}