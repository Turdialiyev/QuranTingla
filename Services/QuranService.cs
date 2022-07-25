using Microsoft.EntityFrameworkCore;
using SurahSender.Data;
using SurahSender.Entities;

namespace SurahSender.Services;

public class QuranService
{
    private readonly AppDbContext _context;

    public QuranService(AppDbContext context)
    {
        _context = context;
    }
    // addeing information of Qquran to data 
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddDataAsync(Quran quran)
    {
        if (await Exists(quran.IdOfMessage))
            return (false, "Quran exists");
        try
        {
            var result = await _context.Qurans.AddAsync(quran);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }
    public async Task<bool> Exists(long idOfMessage)
        => await _context.Qurans.AnyAsync(u => u.IdOfMessage == idOfMessage);

    // addeing information of user to data 
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddUserAsync(User user)
    {
        if (await ExistsUser(user.UserId))
            return (false, "User already exsist");
        try
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }
    public async Task<bool> ExistsUser(long userId)
        => await _context.Users.AnyAsync(u => u.UserId == userId);
}