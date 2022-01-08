using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProfileInProject
    {
        [Key, ForeignKey("Profile"), Column(Order = 0)]
        public string ProfileId { get; set; }

        [Key, ForeignKey("Project"), Column(Order = 1)]
        public int ProjectID { get; set; }


        public virtual Profile Profile { get; set; }
        public virtual Project Project { get; set; }




    }
}
