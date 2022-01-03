using CVSITE21.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(SavedByUser))]
        public string SavedByUserId { get; set; }
        public virtual ApplicationUser SavedByUser { get; set; }


        [ForeignKey("ProfileEmail")]
        public string Email { get; set; }
        public virtual Profile ProfileEmail { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
