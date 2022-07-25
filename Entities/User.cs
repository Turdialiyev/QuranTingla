namespace SurahSender.Entities;

public class User
{
    public Guid Id { get; set; }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserNmae { get; set; }
    public DateTime DateTime { get; set; }

}