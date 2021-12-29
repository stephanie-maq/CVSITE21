using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Skills { get; set; }
        public string Languages { get; set; }
        public string ImagePath { get; set; }
    }
}
