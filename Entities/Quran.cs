namespace SurahSender.Entities;

public class Quran
{
    public Guid Id { get; set; }
    public long MessageId {get; set;}
    public string? Name { get; set; }
    public int Size { get; set; }

}