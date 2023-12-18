namespace JPW.DTO
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string? CompanyPhone { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyDescription { get; set; }
        public string Password { get; set; } = null!;
    }
}
