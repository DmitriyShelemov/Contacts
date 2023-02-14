using ContactsApi.Database;
using System.Text.Json.Serialization;

namespace ContactsApi.Logic.Dto;

public class CompanyContactCreateDto : CompanyContact
{
    [JsonIgnore]
    public override long Id { get => base.Id; set => base.Id = value; }

    [JsonIgnore]
    public override long CompanyId { get => base.CompanyId; set => base.CompanyId = value; }

    [JsonIgnore]
    public override long ContactId { get => base.ContactId; set => base.ContactId = value; }
}
