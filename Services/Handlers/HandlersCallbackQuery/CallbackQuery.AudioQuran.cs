using SurahSender.Services.Handler;
using SurahSender.Services.MarcupHelper;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private async Task HandleAudioQuranAsync(ITelegramBotClient botClient,
                                       CallbackQuery query,
                                       CancellationToken cancellationToken)
    {
        var collectionOfData = _context.Qurans
                            .Where(p =>p.Name.Substring(p.Name.Length - 5, p.Name.Length) == "audio" && p.Name.Substring(p.Name.Length - 14 ,p.Name.Length ) != "darslari_audio")
                            .Select(p => p).ToList();

        var buttonOfQuery = query.Data ?? string.Empty;
        var keyOfButton = "audio";

        var buttons = ButtonOfData.ButtonsOfData(collectionOfData, buttonOfQuery, keyOfButton);
       
        if (buttonOfQuery != "audio1_10")
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