
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SurahSender.Services;
public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(
        ITelegramBotClient botClient,
        Message? message,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From;

        _logger.LogInformation("Received message from {from.FirstName} ", from?.FirstName);

        var handler = message.Type switch
        {
            MessageType.Text => HandleTextMessageAsync(botClient, message, cancellationToken),
            _ => HandleUnknownMessageAsync(botClient, message, cancellationToken),
        };
        await handler;
    }
    private Task HandleUnknownMessageAsync(ITelegramBotClient botClient,
                                           Message message,
                                           CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received message type {message.Type}", message.Type);

        return Task.CompletedTask;
    }

    private async Task HandleTextMessageAsync(ITelegramBotClient botClient,
                                              Message message,
                                              CancellationToken token)
    {
        var from = message.From;

        _logger.LogInformation("From: {from.Firstname} : {message.Text} | Msg ID: {message.MessageId} | ChatID: {message.Chat.Id}", from?.FirstName, message.Text, message.MessageId, message.Chat.Id);

        var handler = message.Text switch
        {
            "/start" => HandleStartAsync(botClient, message, token),
            _ => Task.CompletedTask
        };

        await handler;
    }
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
        await botClient.SendPhotoAsync(
            message.Chat.Id,
            photo: "https://github.com/Turdialiyev/Information/blob/main/picture/photo_2022-07-28_18-52-50.jpg?raw=true",
            cancellationToken: cancellationToken);
         
        await botClient.SendTextMessageAsync(
            message.Chat.Id,
            text: $"🎉 \t\t\t\t\t\t\t\t\t\t {message.From?.FirstName ?? "👻"} \t\t\t\t\t\t\t\t\t\t  🎉  \n\n" +
                "📿 Qur'on tingla 🤖 botga  xush kelibsiz! \n\n🛒 Bo'limni tanlang 👀 👇",
            replyMarkup: selectSection,
            cancellationToken: cancellationToken);
    }
}

