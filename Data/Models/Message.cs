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

        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "The message can't exceed {1} characters.")]
        public string Text { get; set; }

        public string Recipient { get; set; }

        [Display(Name = "Read")]
        public bool isRead { get; set; }

    }
}