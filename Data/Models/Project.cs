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

        [ForeignKey("ProfileEmail")]
        public string Email { get; set; }
        public virtual Profile ProfileEmail { get; set; }

        [Required(ErrorMessage = "Please enter a title for your project")]
        public string Title { get; set; }
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Please enter a description for your project")]
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public ICollection<ProfileInProject> ActiveUsers { get; set; }
    }
}
