using ContactsApi.Domain;
using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApi.Database;

[Table("Companies")]
public class Company
{
    [Key, Identity]
    public virtual long Id { get; set; }

    public string Name { get; set; } = null!;

    public long CountryId { get; set; }

    public long? StateId { get; set; }

    public string ZipCode { get; set; } = null!;

    public CompanyType CompanyType { get; set; }

    public string City { get; set; } = null!;

    public string CompanyMainLine { get; set; } = null!;
}
