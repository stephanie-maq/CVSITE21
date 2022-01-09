using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;

namespace CVSITE21.Models
{
    public class SendMessageViewModel
    {
        public Profile Profile { get; set; }
        public Message Message { get; set; }
    }
}