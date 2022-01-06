using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared
{
    public class ProfileCreateModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string WorkExperiences { get; set; }
        public string AcademicExperiences { get; set; }
        public string Skills { get; set; }

        public bool IsPrivate { get; set; }

        public int? ProjectId { get; set; }

        public List<ProfileCreateProjectsModel> Projects { get; set; }
    }

    public class ProfileCreateProjectsModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}
