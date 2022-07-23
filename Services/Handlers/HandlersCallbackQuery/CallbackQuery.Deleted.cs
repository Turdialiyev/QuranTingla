using Telegram.Bot;
using Telegram.Bot.Types;
using SurahSender.Services.MarcupHelper;
using SurahSender.Services.Handler;


namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    public async Task HandlerDeletedAsync(ITelegramBotClient botClient, CallbackQuery query, CancellationToken cancellationToken)
    {
        await botClient.DeleteMessageAsync(
                      query.Message.Chat.Id,
                      query.Message.MessageId,
                      cancellationToken: cancellationToken);
    }

}