using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Data.Models;

namespace CVSITE21.Models
{
    public class MessageViewModel
    {
        public ICollection<Message> messages { get; set; }

        public int MessageId { get; set; }


        [StringLength(100, ErrorMessage = "Message must have minimum of {2} characters.", MinimumLength = 3)]
        [Display(Name = "Text:")]
        public string Text { get; set; }

        public string Receiver { get; set; }
        public bool isRead { get; set; }


        [Display(Name = "From:")]
        public string Sender { get; set; }

        [Display(Name = "To:")]
        public string ReciverName { get; set; }
    }
}