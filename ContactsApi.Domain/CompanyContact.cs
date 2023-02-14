using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApi.Database;

[Table("CompanyContacts")]
public class CompanyContact
{
    [Key, Identity]
    public virtual long Id { get; set; }

    public virtual long CompanyId { get; set; }

    public virtual long ContactId { get; set; }

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DirectLine { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? SecondLine { get; set; }
}
