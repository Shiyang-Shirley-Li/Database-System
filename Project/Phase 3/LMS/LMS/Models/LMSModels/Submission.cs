using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Submission
    {
        public uint Score { get; set; }
        public string Contents { get; set; }
        public DateTime Time { get; set; }
        public string Id { get; set; }
        public uint AsId { get; set; }
        public uint SubmissionId { get; set; }

        public virtual Assignments As { get; set; }
        public virtual Students IdNavigation { get; set; }
    }
}
