using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Profile
    {
        [Key]
        public string Email { get; set; }

        public string Fullname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string ImagePath { get; set; }

        public ICollection<AcademicExperience> AcademicExperiences { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Skills> Skills { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
