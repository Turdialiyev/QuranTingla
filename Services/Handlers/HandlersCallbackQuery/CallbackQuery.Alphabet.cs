using SurahSender.Services.Handler;
using SurahSender.Services.MarcupHelper;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
 private async Task HandleAlphabetAsync(ITelegramBotClient botClient, CallbackQuery query, CancellationToken cancellationToken)
    {
         var collectionOfData = _context.QuranVideoes
                            .Where(p => p.Name.Substring(p.Name.Length - 10, p.Name.Length) == "dars_video")
                            .Select(p => p).ToList();
        
        var buttonOfQuery = query.Data ?? string.Empty;
        var keyOfButton= "dars_video";

        var buttons = ButtonOfData.ButtonsOfData(collectionOfData, buttonOfQuery, keyOfButton);
        
        if (buttonOfQuery != "dars_video1_10")
        {
            await botClient.DeleteMessageAsync(
                query.Message.Chat.Id,
                query.Message.MessageId,
                cancellationToken: cancellationToken);
        } 

        await botClient.SendTextMessageAsync(
            query.Message.Chat.Id,
            text: "Natijalar " + (buttons.Item2 - 9) + "-" + buttons.Item1 + " dan\n\n" + buttons.Item3,
            replyMarkup: MarcupHelpers.GetKeyboardMarkup(buttons.Item4, buttons.Item5),
            cancellationToken: cancellationToken);
    }
}