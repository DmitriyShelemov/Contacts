using ContactsApi.Database;
using ContactsApi.Domain;
using System.Text.Json.Serialization;

namespace ContactsApi.Logic.Dto;

public class CompanyCreateDto : Company
{
    [JsonIgnore]
    public override long Id { get => base.Id; set => base.Id = value; }
}
