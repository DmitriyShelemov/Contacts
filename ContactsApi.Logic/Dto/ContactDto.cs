namespace ContactsApi.Logic.Dto;

public class ContactDto
{
    public long BusinessInfoId { get; set; }

    public long CompanyId { get; set; }

    public long ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime LastContactedDate { get; set; }
}
