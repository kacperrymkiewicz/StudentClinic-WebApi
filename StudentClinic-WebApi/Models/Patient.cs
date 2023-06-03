namespace StudentClinic_WebApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Pesel { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Allergies { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
