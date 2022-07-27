using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private QuranService _quranService;

    private async Task HandlerChannelPostAsync(ITelegramBotClient botClient, Message? channelPost, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(channelPost);

        using var scope = _scopeFactory.CreateScope();

        _quranService = scope.ServiceProvider.GetRequiredService<QuranService>();

        var channelId = channelPost.Chat.Id;
        var messageId = channelPost.MessageId;
        var name = channelPost.Caption ?? string.Empty;
        var type = channelPost.Type;

        _logger.LogInformation("id  =>  {id}", type);

        var handlerCannel = type switch
        {
            MessageType.Text  => HandlerChannelPostTextAsync(botClient, channelPost, cancellationToken), 
            MessageType.Video => HandlerChannelPostVideoAsync(botClient, channelPost, cancellationToken),
            MessageType.Audio => HandlerChannelPostAudioAsync(botClient, channelPost, cancellationToken),
            _ => HandlerUnknownAsync(botClient, channelPost, cancellationToken)

        };

    }

}