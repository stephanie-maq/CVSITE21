using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ProjectWithProfilesForList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public List<string> ListOfHiddenProfiles { get; set; }
        public List<string> ListOfNormalProfiles { get; set; }
    

    public ProjectWithProfilesForList(int projectID, string title, string createdBy, string description, DateTime dateCreated)
    {
        Id = projectID;
        Title = title;
        CreatedBy = createdBy;
        Description = description;
        DateCreated = dateCreated;
    }

    }
}
