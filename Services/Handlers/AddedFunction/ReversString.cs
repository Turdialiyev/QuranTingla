namespace SurahSender.Services.Handler.AddedFunction;

public static class ReversString
{
     //Revers
    public static string Reverse(string Input)
    {

        // Converting string to character array
        char[] charArray = Input.ToCharArray();

        // Declaring an empty string
        string reversedString = String.Empty;

        int length, index;
        length = charArray.Length - 1;
        index = length;

        // Iterating the each character from right to left 
        while (index > -1)
        {

            // Appending character to the reversedstring.
            reversedString = reversedString + charArray[index];
            index--;
        }

        // Return the reversed string.
        return reversedString;
    }
}