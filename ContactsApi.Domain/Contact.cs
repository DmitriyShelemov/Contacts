using ContactsApi.Domain;
using MicroOrm.Dapper.Repositories.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Database;

public class Contact
{
    [Key, Identity]
    public virtual long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public TitleType TitleType { get; set; }

    public string? Notes { get; set; }

    public long CountryId { get; set; }

    public string ZipCode { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long? StateId { get; set; }

    public string City { get; set; } = null!;

    public string? PersonalMobile1 { get; set; }

    public string? PersonalMobile2 { get; set; }

    public string? HomePhone { get; set; }

    public string? LinkedIn { get; set; }

    public string PersonalEmail { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual DateTime CreateDate { get; set; }

    public virtual DateTime LastContactedDate { get; set; }
}
