using SurahSender.Services.Handler.AddedFunction;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    private async Task HandlerChannelPostTextAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        var note = "Bizda hozircha Asosiy bo'limda 4ta katigoriya mavjud.\n\n1. Quran Surahlari Video Korinishida\n2. Arab Alifbosi Video Korinishida\n3. Quran Surahlari Audio Korinishida\n4. Quran Matni matn Joylangan bolimga \n\n❌   Eslatma  !\n\n✅ Video Quran surahlari 1 - 114 gacha surahlarni kiriting albatta surrah nomi, nomidan kegin surah_video kalit sozni yozilishi shart.\n\n✅ Arab alifbosi ketmaketligda kiritib boriladi nomi, nomidan kegin alifbo_vidoe\n\n✅  Audio Quran surahlari 1 - 114 gacha surahlarni kiriting albatta surrah nomi, nomidan kegin surah_audio kalit sozi yozilishi shart.";
        var getMe = botClient.BotId;
        var text = channelPost.Text;

        if (text == "start")
        {

            await botClient.SendTextMessageAsync(
                 channelPost.Chat.Id,
                 text: note,
                 cancellationToken: cancellationToken);
        }
        else
        {
            await botClient.SendPhotoAsync(
                channelPost.Chat.Id,
                photo: "https://raw.githubusercontent.com/Turdialiyev/Information/main/picture/iStock-872962368-chat-bots.jpg",
                caption: "<b> Kechirasiz bunday text farmatlarni qabulqila olmayman<i> start </i> buyrug'i yuborish oraqli men bilan bog'laning</b>. <i>My linke </i>: <a href=\"https://t.me/Imon_Islomdandur_bot\">Bot</a>",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
        }


    }
    private async Task HandlerChannelPostVideoAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {

        var revers = ReversString.Reverse(channelPost.Caption);
        int index = revers.IndexOf(" ");
        var key = revers.Substring(0, index);
        key = ReversString.Reverse(key);

        if (key == "surah_video" || key == "alifbo_video")
        {
            var result = await _quranService.AddVideoDataAsync(new Entities.QuranVideo()
            {
                MessageId = (int)channelPost.MessageId,
                Name = channelPost.Caption,

            });

            if (result.IsSuccess)
            {
                _logger.LogInformation($"New Quran Video successfully added: {channelPost.Chat.Id}, Name: {channelPost.Caption}");

                await botClient.SendTextMessageAsync(
                    channelPost.Chat.Id,
                    text: "✅",
                    cancellationToken: cancellationToken);

            }
            else
            {
                _logger.LogInformation($"Quran video not added: {channelPost.Chat.Id}, Error: {result.ErrorMessage}");
            }
        }
        else
        {
            _logger.LogInformation("iltimos kalit sozni kiriting kalit sozn ");
            await botClient.SendTextMessageAsync(
                     channelPost.Chat.Id,
                     text: "❌ kalit soz qoyish shart",
                     cancellationToken: cancellationToken);
        }


    }
    private async Task HandlerChannelPostAudioAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    private async Task HandlerUnknownAsync(ITelegramBotClient botClient, Message channelPost, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(
            channelPost.Chat.Id,
            text: "note",
            cancellationToken: cancellationToken);
    }


}