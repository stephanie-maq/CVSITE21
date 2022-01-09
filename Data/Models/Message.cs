using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "From")]
        public string Sender { get; set; }

        public string Text { get; set; }

        public string Recipient { get; set; }

        [Display(Name = "Read")]
        public bool isRead { get; set; }

    }
}