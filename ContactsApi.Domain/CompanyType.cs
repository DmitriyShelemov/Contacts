using System.Text.Json.Serialization;

namespace ContactsApi.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanyType
    {
        LimitedParthner,
        Sponsor
    }
}
