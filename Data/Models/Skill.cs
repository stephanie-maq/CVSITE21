using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProfileEmail")]
        public string Email { get; set; }
        public virtual Profile ProfileEmail { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }

    }
}