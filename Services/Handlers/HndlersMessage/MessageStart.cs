using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SurahSender.Services;


public partial class BotUpdateHandler
{

    private async Task HandleStartAsync(ITelegramBotClient botClient,
                                        Message message,
                                        CancellationToken cancellationToken)
    {

        ArgumentNullException.ThrowIfNull(message);

        using var scope = _scopeFactory.CreateScope();

        _quranService = scope.ServiceProvider.GetRequiredService<QuranService>();

        var userId = message.From?.Id;
        var firstName = message.From?.FirstName;
        var lastName = message.From?.LastName;
        var userName = message.From?.Username;

        _logger.LogInformation("Message {id}", userId);

        var result = await _quranService.AddUserAsync(new Entities.User()
        {
            UserId = (long)userId,
            FirstName = firstName,
            LastName = lastName,
            UserNmae = userName,
            DateTime = DateTime.Now
        });

        if (result.IsSuccess)
        {
            _logger.LogInformation($"New User  successfully added: {userId}");
        }
        else
        {
            _logger.LogInformation($"User not added: {userId}, Error: {result.ErrorMessage}");
        }
        await botClient.SendStickerAsync(
            message.Chat.Id,
            sticker: "https://raw.githubusercontent.com/Turdialiyev/Information/main/sticker/islom.webp",
            cancellationToken: cancellationToken);

        await botClient.SendTextMessageAsync(
            message.Chat.Id,
            text: $"🎉 \t\t\t\t\t\t\t\t\t\t {message.From?.FirstName ?? "👻"} \t\t\t\t\t\t\t\t\t\t  🎉  \n\n" +
                "📿 Qur'on tingla 🤖 botga  xush kelibsiz! \n\n🛒 Bo'limni tanlang 👀 👇",
            replyMarkup: selectSection,
            cancellationToken: cancellationToken);

    }
}