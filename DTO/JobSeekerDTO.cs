namespace JPW.DTO
{
    public class JobSeekerDTO
    {
        public string JobSeekerName { get; set; } = null!;
        public string? Gender { get; set; }
        public string Email { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public string? Skills { get; set; }
        public string Password { get; set; } = null!;
    }
}
