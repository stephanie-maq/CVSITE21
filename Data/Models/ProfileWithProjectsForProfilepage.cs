using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{   
    public class ProfileWithProjectsForProfilepage
    {
        public string UserId { get; set; }

        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string ImagePath { get; set; }

        public string AcademicExperiences { get; set; }
        public string Skills { get; set; }
        public string WorkExperiences { get; set; }
        public List<string> ListOfProject { get; set; }


        public ProfileWithProjectsForProfilepage(string userId, string email, string fullname, string address, int age, string imagePath, string academicExperiences, string skills, string workExperiences)
        {
            UserId = userId;
            Email = email;
            Fullname = fullname;
            Address = address;
            Age = age;
            ImagePath = imagePath;
            AcademicExperiences = academicExperiences;
            Skills = skills;
            WorkExperiences = workExperiences;
        }

        public ProfileWithProjectsForProfilepage(Profile profile)
        {
        }
    }
}
