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

        if (name != string.Empty && channelId == -1001709192461)
        {
           var handlerCannel = type switch
           {

            MessageType.Video => HandlerChannelPostVideoAsync(botClient, channelPost, cancellationToken, name, messageId),
            MessageType.Audio => HandlerChannelPostAudioAsync(botClient, channelPost, cancellationToken),
            _=>HandlerUnknownAsync(botClient, channelPost, cancellationToken)
           
           };
        }


        
    }

    
}