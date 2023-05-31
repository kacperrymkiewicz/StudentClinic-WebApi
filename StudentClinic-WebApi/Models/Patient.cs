namespace StudentClinic_WebApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Allergies { get; set; }

    }
}
