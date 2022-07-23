
using Telegram.Bot.Types.ReplyMarkups;

namespace SurahSender.Services;

public partial class BotUpdateHandler
{
    InlineKeyboardMarkup selectSection = new(new[]
     {
            // first row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "🎧  Audio Qur'on", callbackData: "audio1_10"),
            InlineKeyboardButton.WithCallbackData(text: "▶️  Video Qur'on", callbackData: "video1_10"),
        },
        // second row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "📖 Qur'on matni", callbackData: "_textQuran"),
            InlineKeyboardButton.WithCallbackData(text: "🔤  Arab Alifbosi", callbackData: "dars1_video_10"),
        },
    });

    InlineKeyboardMarkup reciters = new(new[]
    {
        // first row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "👳🏻‍♂️  Mishary bin Rashid", callbackData: "_reciters1"),
            InlineKeyboardButton.WithCallbackData(text: "👳🏻‍♂️  Saad Al Ghamdi", callbackData: "_reciters2"),
        },
        // second row
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "👳🏻‍♂️  Ahmad bin Ali Al-Ajmi.", callbackData: "_reciters3"),
        },
    });


    InlineKeyboardMarkup books = new(new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "📖 Asl Qur'oni Karim", callbackData: "_arabBook"),
            InlineKeyboardButton.WithCallbackData(text: "📖 Qur'oni Karim uzb tarjima", callbackData: "_uzBook"),

        },
        new []
        {
            InlineKeyboardButton.WithCallbackData(text: "❌", callbackData: "deleted"),

        },
    });
}