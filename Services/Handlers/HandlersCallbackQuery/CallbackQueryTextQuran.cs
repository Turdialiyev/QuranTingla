using Telegram.Bot;
using Telegram.Bot.Types;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private async Task HandleTextQuranAsync(ITelegramBotClient botClient,
                                      CallbackQuery query,
                                      CancellationToken cancellationToken)
    {

        if (query.Data == "_textQuran")
        {
            await botClient.SendTextMessageAsync(
                query.Message.Chat.Id,
                text: "Qaysi tilda o'qimoqchisiz?",
                replyMarkup: books,
                cancellationToken: cancellationToken);
        }
        else if (query.Data == "_uzBook")
        {
            var root = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(root, "quroni-karim-alouddin-mansur.pdf");

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);

            using var stream = new MemoryStream(bytes);

            await botClient.SendDocumentAsync(
                query.Message.Chat.Id,
                document: stream,
                caption: "📖 Qur'oni Karim. Alouddin Mansur Tarjimasi ",
                cancellationToken: cancellationToken);
        }
        else if (query.Data == "_arabBook")
        {
            var root = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(root, "Quran.pdf");

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);

            using var stream = new MemoryStream(bytes);

            await botClient.SendDocumentAsync(
                query.Message.Chat.Id,
                document: stream,
                caption: "📖 Qur'oni Karim",
                cancellationToken: cancellationToken);
        }

    }
}