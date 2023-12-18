namespace JPW.DTO
{
    public class JobpostingDTO
    {
        public string JobTitle { get; set; } = null!;
        public string? JobDescription { get; set; }
        public string? JobExperienceLevel { get; set; }
        public string? JobSkillSet { get; set; }
        public string? JobPayScale { get; set; }
        public string? JobLocation { get; set; }
        // public DateTime? StartDate { get; set; }
        // public DateTime? EndDate { get; set; }
        public int CompanyId { get; set; }
       
        

    }
}
