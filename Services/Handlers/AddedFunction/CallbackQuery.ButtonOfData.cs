using SurahSender.Services.Handler.AddedFunction;

namespace SurahSender.Services.Handler;

public static class ButtonOfData
{
    public static Tuple<int, int, string, Dictionary<string, string>, int> ButtonsOfData(List<Entities.Quran> collectionOfData, string buttonOfQuery, string keyOfButton)
    {
        var result = collectionOfData.Count();
        var text = "";
        var dictionary = new Dictionary<string, string>();
        var revers1 = ReversString.Reverse(buttonOfQuery);
        var index1 = revers1.IndexOf("_");
        var revers2 = ReversString.Reverse(revers1.Substring(0, index1));
        var prceed = int.Parse(revers2);
        int increaseOfData = 0;
        int ikonsOfData = 0;
        int row = 5;

        if (prceed < collectionOfData?.Count())
        {
            row = 5;

            for (int i = prceed - 10; i < prceed; i++)
            {
                ikonsOfData++;
                var key = collectionOfData[i].IdOfMessage + "";
                var value = ikonsOfData + "";
                var name = collectionOfData[i].Name;
                var index = name.IndexOf(' ');

                if (keyOfButton == "dars_video" || keyOfButton == "dars_audio")
                {
                    name = name.Substring(index, name.Length - index);
                }

                text += (i + 1) + " ." + name + "\n";

                dictionary.Add(value, key);

            }

            ikonsOfData = 0;
            increaseOfData = prceed;
            prceed += 10;

            string valueOfvideo = keyOfButton + "_" + prceed.ToString();

            if (prceed > 20)
            {
                dictionary.Add("⬅️", keyOfButton + "_" + (prceed - 20));
            }

            dictionary.Add("❌", "deleted");
            dictionary.Add("➡️", valueOfvideo);

        }

        else if (collectionOfData?.Count() / 10 > 0)
        {
            increaseOfData = collectionOfData?.Count() - (collectionOfData?.Count() % 10) + 10 ?? 0;

            for (int i = prceed - 10; i < collectionOfData?.Count(); i++)
            {
                ikonsOfData += 1;
                var key = collectionOfData[i].IdOfMessage + "";
                var value = ikonsOfData + "";
                var name = collectionOfData[i].Name;
                var index = name.IndexOf(' ');

                if (keyOfButton == "dars_video" || keyOfButton == "dars_audio")
                {
                    name = name.Substring(index, name.Length - index);
                }

                text += (i + 1) + " ." + name + "\n";

                dictionary.Add(value, key);
            }

            ikonsOfData += 1;

            dictionary.Add("❌", "deleted");
            dictionary.Add("⬅️", keyOfButton + "_" + (prceed - 10));

        }
        else
        {
            row = 5;
            increaseOfData = 9;

            for (int i = prceed - 10; i < collectionOfData?.Count(); i++)
            {
                var key = collectionOfData[i].IdOfMessage + "";
                var value = (i + 1) + "";
                var name = collectionOfData[i].Name;
                var index = name.IndexOf(' ');

                if (keyOfButton == "dars_video" || keyOfButton == "dars_audio")
                {
                    name = name.Substring(index, name.Length - index);
                }

                dictionary.Add("❌", "deleted");
                text += (i + 1) + " ." + name + "\n";

                dictionary.Add(value, key);

            }

        }

        return Tuple.Create(result, increaseOfData, text, dictionary, row);

    }

}