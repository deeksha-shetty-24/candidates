namespace Candidate.Model
{
    public class ApplicantModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int ExperienceInYears { get; set; }

        public byte[] ResumeFile { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}
