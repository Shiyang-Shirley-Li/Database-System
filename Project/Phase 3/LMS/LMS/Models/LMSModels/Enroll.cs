using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Enroll
    {
        public string Grade { get; set; }
        public string Id { get; set; }
        public uint ClassId { get; set; }
        public uint EnroId { get; set; }

        public virtual Classes Class { get; set; }
        public virtual Students IdNavigation { get; set; }
    }
}
