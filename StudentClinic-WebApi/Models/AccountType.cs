using System.Text.Json.Serialization;

namespace StudentClinic_WebApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountType
    {
        Patient = 1,
        Doctor = 2,
        Receptionist = 3
    }
}
