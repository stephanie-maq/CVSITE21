using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CVSITE21.Data;

namespace Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "From")]
        public string Sender { get; set; }
        public string Text { get; set; }
        public string Receiver { get; set; }
        public bool Read { get; set; }


    }
}