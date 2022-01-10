﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Profile
    {
        [Key] public string UserId { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Academic Experiences")]
        public string AcademicExperiences { get; set; }
        public string Skills { get; set; }
        [Display(Name = "Work Experiences")]
        public string WorkExperiences { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<ProfileInProject> ActiveInProjects { get; set; }
    }
}
