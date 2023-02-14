using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApi.Database;

[Table("Users")]
public class User
{
    [Key, Identity]
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
