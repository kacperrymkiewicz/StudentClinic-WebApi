using System.Text.Json.Serialization;

namespace StudentClinic_WebApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VisitStatus
    {
        Unconfirmed,
        Confirmed,
        Finished,
        Canceled
    }
}