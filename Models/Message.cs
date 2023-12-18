using System;
using System.Collections.Generic;

namespace JPW.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int JobSeekerId { get; set; }
        public int CompanyId { get; set; }
        public string? MessageText { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual JobSeeker JobSeeker { get; set; } = null!;
    }
}
