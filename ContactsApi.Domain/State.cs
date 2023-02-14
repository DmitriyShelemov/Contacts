using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Database;

public class State
{
    [Key, Identity]
    public long Id { get; set; }

    public long CountryId { get; set; }

    public string Name { get; set; } = null!;
}
