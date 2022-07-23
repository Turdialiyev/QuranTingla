using Telegram.Bot;
using Telegram.Bot.Types;
namespace SurahSender.Services;
public partial class BotUpdateHandler
{
    private async Task HandlerButtonAsync(ITelegramBotClient botClient, CallbackQuery query, CancellationToken cancellationToken, string? key)
    {
        var item = _context?.Qurans?.First(q => q.IdOfMessage.ToString() == key);
        var idOfMessage = item?.IdOfMessage;
        await botClient.ForwardMessageAsync(
            chatId: query.Message.Chat.Id,
            fromChatId: -1001407276572,
            (int)item.IdOfMessage,
            cancellationToken: cancellationToken);
    }
}
