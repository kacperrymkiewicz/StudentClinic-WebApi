namespace StudentClinic_WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AccountType AccountType { get; set; } = AccountType.Patient;
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
