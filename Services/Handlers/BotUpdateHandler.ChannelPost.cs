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
        var type = channelPost.Type;
        var caption = channelPost.Caption;
        _logger.LogInformation($"{channelId}");

        if (channelId == -1001709192461)
        {
            var handler = channelPost.Type switch
                    {

                        MessageType.Audio or MessageType.Video => HandleVidoAudioAsync(botClient, channelPost, cancellationToken),
                        _ => HandleUnknownchannelAsync(botClient, channelPost, cancellationToken),
                    
                    };
        }

    }

    

   }