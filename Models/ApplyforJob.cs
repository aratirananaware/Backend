using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class ApplyforJob
    {
        public int AppliedJobId { get; set; }
        public int JobSeekerId { get; set; }
        public int JobId { get; set; }
        
        public int CompanyId {get; set;}
        
        //public byte[]? Resume { get; set; }
       public string Resume {get; set;}

        public virtual JobPosting Job { get; set; } = null!;
        public virtual JobSeeker JobSeeker { get; set; } = null!;
    }
}
