using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private QuranService _quranService;

    private async Task HandlerChannelPostAsync(ITelegramBotClient botClient, Message? channelPost, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(channelPost);

        using var scope = _scopeFactory.CreateScope();
        
        _quranService = scope.ServiceProvider.GetRequiredService<QuranService>();
        
        var messageId = channelPost.MessageId;
        var name = channelPost.Caption;
        var size = 1;

        _logger.LogInformation("Id Of message {id}", messageId);

        var result = await _quranService.AddDataAsync(new Entities.QuranVideo()
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
}