using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SurahSender.Entities;

public class QuranAudio
{
    public Guid Id { get; set; }
    public int MessageId {get; set;}
    public string? Name { get; set; }

}