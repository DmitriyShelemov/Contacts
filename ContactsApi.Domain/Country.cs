using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Database;

public class Country
{
    [Key, Identity]
    public long Id { get; set; }

    public string Name { get; set; } = null!;
}
