namespace StudentClinic_WebApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Pesel { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Allergies { get; set; }
        public string? MedicationsTaken { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? StreetAddress { get; set; }
        public DateOnly? BirthDate { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public List<Visit>? Visits { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
    }
}
