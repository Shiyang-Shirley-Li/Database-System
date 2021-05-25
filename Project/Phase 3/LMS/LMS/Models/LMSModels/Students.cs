using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Students
    {
        public Students()
        {
            Enroll = new HashSet<Enroll>();
            Submission = new HashSet<Submission>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string SubjectAbbreviation { get; set; }

        public virtual Departments SubjectAbbreviationNavigation { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
