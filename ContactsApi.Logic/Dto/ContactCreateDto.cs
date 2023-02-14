using ContactsApi.Database;
using System.Text.Json.Serialization;

namespace ContactsApi.Logic.Dto;

public class ContactCreateDto : Contact
{
    [JsonIgnore]
    public override long Id { get => base.Id; set => base.Id = value; }

    [JsonIgnore]
    public override DateTime CreateDate { get => base.CreateDate; set => base.CreateDate = value; }

    [JsonIgnore]
    public override DateTime LastContactedDate { get => base.LastContactedDate; set => base.LastContactedDate = value; }

    public long? CompanyId { get; set; }

    public CompanyCreateDto? Company { get; set; }

    public CompanyContactCreateDto BusinessInfo { get; set; } = null!;
}
