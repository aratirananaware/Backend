using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class JobPosting
    {
        public JobPosting()
        {
            ApplyforJobs = new HashSet<ApplyforJob>();
            JobMatches = new HashSet<JobMatch>();
        }

        public int JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string? JobDescription { get; set; }
        public string? JobExperienceLevel { get; set; }
        public string? JobSkillSet { get; set; }
        public string? JobPayScale { get; set; }
        public string? JobLocation { get; set; }
        // public DateTime? StartDate { get; set; }
        // public DateTime? EndDate { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
         public virtual ICollection<ApplyforJob> ApplyforJobs { get; set; }
        public virtual ICollection<JobMatch> JobMatches { get; set; }
    }
}
