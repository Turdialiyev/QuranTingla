using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    
    private async Task HandlerChannelPostVideoAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken, string name, int messageId)
    {

        var result = await _quranService.AddVideoDataAsync(new Entities.QuranVideo()
        {
            MessageId = messageId,
            Name = name,

        });

        if (result.IsSuccess)
        {
            _logger.LogInformation($"New Quran Video successfully added: {messageId}, Name: {name}");
        }
        else
        {
            _logger.LogInformation($"Quran video not added: {messageId}, Error: {result.ErrorMessage}");
        }
    }
    private async Task HandlerChannelPostAudioAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    private Task HandlerUnknownAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


}