using System.Text.Json.Serialization;

namespace ContactsApi.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TitleType
    {
        Mr,
        Mrs,
        Ms,
        Miss
    }
}
