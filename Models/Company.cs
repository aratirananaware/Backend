using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class Company
    {
        public Company()
        {
            JobPostings = new HashSet<JobPosting>();
            Messages = new HashSet<Message>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string? CompanyPhone { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyDescription { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<JobPosting> JobPostings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
