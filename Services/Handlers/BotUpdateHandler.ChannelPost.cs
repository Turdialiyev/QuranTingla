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


        _logger.LogInformation("id  =>  {id}", channelId);
        if (channelId == -1001709192461)
        {

            var handlerCannel = type switch
            {
                MessageType.Text => HandlerChannelPostTextAsync(botClient, channelPost, cancellationToken),
                MessageType.Video => HandlerChannelPostVideoAsync(botClient, channelPost, cancellationToken),
                MessageType.Audio => HandlerChannelPostAudioAsync(botClient, channelPost, cancellationToken),
                _ => HandlerUnknownAsync(botClient, channelPost, cancellationToken)

            };

        }
        else if (channelId == -1001770096371)
        {

            
            await botClient.DeleteMessageAsync(
                channelPost.Chat.Id,
                channelPost.MessageId,
                cancellationToken: cancellationToken);

            await botClient.SendPhotoAsync(
                channelPost.Chat.Id,
                photo: "https://raw.githubusercontent.com/Turdialiyev/Information/main/picture/iStock-872962368-chat-bots.jpg",
                caption: "<b> Kechirasiz bu kanaldan habar yubora olmaysiz. Foydalanuvchi bilan 📞 orqali bog'laning </b> <i> My linke </i>: <a href=\"https://t.me/Imon_Islomdandur_bot\">Bot</a>",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

        }


    }

}