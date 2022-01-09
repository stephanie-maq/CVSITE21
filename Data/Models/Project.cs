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
        [StringLength(40, MinimumLength = 2, ErrorMessage = "The title should be between {2} and {1} characters.")]
        public string Title { get; set; }
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Please enter a short description for your project")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "The description should be between {2} and {1} characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a date with the following format: mm/dd/yyyy")]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public ICollection<ProfileInProject> ActiveUsers { get; set; }
    }
}
