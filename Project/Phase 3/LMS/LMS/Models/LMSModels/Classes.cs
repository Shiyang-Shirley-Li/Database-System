using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCategories = new HashSet<AssignmentCategories>();
            Enroll = new HashSet<Enroll>();
        }

        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public uint Year { get; set; }
        public string Season { get; set; }
        public uint CId { get; set; }
        public string Id { get; set; }
        public uint ClassId { get; set; }

        public virtual Courses C { get; set; }
        public virtual Professors IdNavigation { get; set; }
        public virtual ICollection<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
    }
}
