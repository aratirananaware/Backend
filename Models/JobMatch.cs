using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class JobMatch
    {
        public int JobMatchId { get; set; }
        public int JobSeekerId { get; set; }
        public int JobId { get; set; }

        public virtual JobPosting Job { get; set; } = null!;
        public virtual JobSeeker JobSeeker { get; set; } = null!;
    }
}
