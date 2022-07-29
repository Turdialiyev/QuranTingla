
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
    
}

