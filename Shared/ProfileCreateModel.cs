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
        public string Address { get; set; }
        public int Age { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string AcademicExperiences { get; set; }
        public string Skills { get; set; }
        public string WorkExperiences { get; set; }
    }
}


