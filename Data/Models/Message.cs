﻿using System;
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
        public string From { get; set; }
        public string Text { get; set; }
        public string Recipient { get; set; }
        public bool IsRead { get; set; }

    }
}
