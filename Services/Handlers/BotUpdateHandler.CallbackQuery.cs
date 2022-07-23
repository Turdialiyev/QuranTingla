using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;
public partial class BotUpdateHandler
{

    private QuranService _scopSelect;
    private int surah;
    private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient,
                                          CallbackQuery query,
                                          CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var key = query.Data ?? string.Empty;

        _logger.LogInformation("Received CallbackQuery from {from.FirstName} : {query.Data}", query.From?.FirstName, query.Data);
        _logger.LogInformation("button is {queryValue}", key);
        int index = key.IndexOf("_");
        
        if (index >= 0)
        {
            index = index;
        }
        else
        {
            index = 0;
        }

        if (key?.Length > 6 && key.Substring(0, index) == "video1" || key?.Length > 6 && key.Substring(0, index) == "video")
        {
            HandleVideoQuranAsync(botClient, query, cancellationToken);
        }
        else if (key?.Length > 6 && key.Substring(0, 5) == "audio" || key?.Length > 6 && key.Substring(0, index) == "audio1")
        {
            HandleAudioQuranAsync(botClient, query, cancellationToken);
        }
        else if (key?.Length > 10 && key.Substring(0, 10) == "dars_video" || key?.Length > 10 && key.Substring(0, index) == "dars1")
        {
            HandleAlphabetAsync(botClient, query, cancellationToken);
        }
        var handler = query.Data switch
        {
            "deleted" => HandlerDeletedAsync(botClient, query, cancellationToken),
            "_textQuran" or "_arabBook" or "_uzBook" => HandleTextQuranAsync(botClient, query, cancellationToken),
            _ => HandlerButtonAsync(botClient, query, cancellationToken, key),
        };

        _logger.LogInformation("_sectionName is {_sectionName}", _sectionName);
        _logger.LogInformation("reciter is {temp}", key);

    }

   
}