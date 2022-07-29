using Telegram.Bot;
using Telegram.Bot.Types;
using SurahSender.Services.Handler.AddedFunction;
using Telegram.Bot.Types.ReplyMarkups;

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
        else if (key == "dars_video1_10" || key?.Length > 10 && key.Substring(0, index) == "dars1")
        {
            HandleAlphabetAsync(botClient, query, cancellationToken);
        }
        var handler = query.Data switch
        {
            "admin" => HAndlerAdminAsync(botClient, query, cancellationToken),
            "deleted" => HandlerDeletedAsync(botClient, query, cancellationToken),
            "_textQuran" or "_arabBook" or "_uzBook" => HandleTextQuranAsync(botClient, query, cancellationToken),
            _ => HandlerButtonAsync(botClient, query, cancellationToken, key),
        };

        _logger.LogInformation("_sectionName is {_sectionName}", _sectionName);
        _logger.LogInformation("reciter is {temp}", key);

    }

    private async Task HAndlerAdminAsync(ITelegramBotClient botClient, CallbackQuery query, CancellationToken cancellationToken)
    {
        // var number = query.From.Id.
        
         await botClient.SendTextMessageAsync(
            chatId: query.Message.Chat.Id,
            text: "number",
            replyMarkup: CreateContactRequestButton("909909090"));         

        _logger.LogInformation("sssssssssssssssssssssssssssss00");
        
    }

    public static ReplyKeyboardMarkup CreateContactRequestButton(string title)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(
            new[]
            {
                KeyboardButton.WithRequestContact(title),
            })
            {
                ResizeKeyboard = true
            };

        return replyKeyboardMarkup;
    }

}