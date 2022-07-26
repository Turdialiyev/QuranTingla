using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private async Task HandleVidoAudioAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        var messageId = channelPost?.MessageId ?? 0;
        var name = channelPost?.Caption;
        var size = 1;

        _logger.LogInformation($"{messageId} =================> ");

        if (name != null)
        {
            var result = await _quranService.AddVideoAsync(new Entities.Quran()
            {

                MessageId = messageId,
                Name = name,
                Size = size

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
        else
        {
            _logger.LogInformation("iltimos name bilan jonating");
        }



    }
    private async Task HandleUnknownchannelAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {

        _logger.LogInformation("only vido or audio");

    }

}