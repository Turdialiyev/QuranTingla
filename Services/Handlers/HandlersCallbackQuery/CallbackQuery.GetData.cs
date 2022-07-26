using Telegram.Bot;
using Telegram.Bot.Types;
namespace SurahSender.Services;
public partial class BotUpdateHandler
{
    private async Task HandlerButtonAsync(ITelegramBotClient botClient, CallbackQuery query, CancellationToken cancellationToken, string? key)
    {
        var item = _context?.QuranVideos?.First(q => q.MessageId.ToString() == key);
        var idOfMessage = item?.MessageId;
        await botClient.ForwardMessageAsync(
            chatId: query.Message.Chat.Id,
            fromChatId: -1001407276572,
            (int)item.MessageId,
            cancellationToken: cancellationToken);
    }
}
