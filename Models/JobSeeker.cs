using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class JobSeeker
    {
        public JobSeeker()
        {
            // ApplyforJobs = new HashSet<ApplyforJob>();
            JobMatches = new HashSet<JobMatch>();
            Messages = new HashSet<Message>();
        }

        public int JobSeekerId { get; set; }
        public string JobSeekerName { get; set; } = null!;
        public string? Gender { get; set; }
        public string Email { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public string? Skills { get; set; }
        public string Password { get; set; } = null!;

         public virtual ICollection<ApplyforJob> ApplyforJobs { get; set; }
        public virtual ICollection<JobMatch> JobMatches { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
