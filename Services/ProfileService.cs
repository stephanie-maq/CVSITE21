using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CVSITE21.Data;
using Data;
using Data.Models;
using Shared;
using Microsoft.AspNet.Identity;

namespace Services
{
    public class ProfileService
    {
        private readonly HttpContext _httpcontext;

        public ProfileService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public void SaveNewProfile(ProfileCreateModel model)
        {
            using (var context = new ApplicationDbContext())
            {



                Profile profile = context.Profiles.Find(_httpcontext.User.Identity.Name);
                profile.WorkExperiences = model.WorkExperiences;
                profile.Age = model.Age;
                profile.Address = model.Address;
                profile.Fullname = model.Fullname;
                profile.AcademicExperiences = model.AcademicExperiences;
                //profile.ImagePath = model.ImagePath;




                var filepath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedImages");
                var filename = model.Image.FileName;
                model.Image.SaveAs(filepath + "/" + filename);

                profile.ImagePath = filename;

                profile.Skills = model.Skills;

                context.SaveChanges();
            };
        }
    }
}


