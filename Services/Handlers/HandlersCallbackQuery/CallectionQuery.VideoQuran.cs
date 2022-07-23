using Telegram.Bot;
using Telegram.Bot.Types;
using SurahSender.Services.MarcupHelper;
using SurahSender.Services.Handler;


namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private string _reciterName = "default";
    private string _sectionName = "default";
    private string _surahName = "default";
    private async Task HandleVideoQuranAsync(ITelegramBotClient botClient,
                                CallbackQuery query,
                                CancellationToken cancellationToken)
    {

        var collectionOfData = _context.Qurans
                               .Where(p => p.Name.Substring(p.Name.Length - 5, p.Name.Length) == "video" && p.Name.Substring(p.Name.Length - 10, p.Name.Length) != "dars_video")
                               .Select(p => p).ToList();
        var buttonOfQuery = query.Data ?? string.Empty;
        var keyOfButton = "video";
        var buttons = ButtonOfData.ButtonsOfData(collectionOfData, buttonOfQuery, keyOfButton);

        if ( buttonOfQuery != "video1_10" )
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