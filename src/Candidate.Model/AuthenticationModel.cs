namespace Candidate.Model
{
    public class AuthenticationModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Error { get; set; } = null!;
    }
}
