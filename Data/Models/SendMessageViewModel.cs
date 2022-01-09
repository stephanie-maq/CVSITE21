using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SendMessageViewModel
    {
        public Profile Profile { get; set; }
        public Message Message { get; set; }
        public string Sender { get; set; }


        public SendMessageViewModel(Profile profile, string sender)
        {
            this.Profile = profile;
            this.Sender = sender;
        }
        public SendMessageViewModel(Profile profile, Message message, string sender)
        {
            this.Profile = profile;
            this.Message = message;
            this.Sender = sender;
        }
        public SendMessageViewModel()
        {
            
        }
    }
}