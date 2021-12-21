using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Project
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string ImagePath { get; set; }

    }
}
