using System.Text.RegularExpressions;

namespace UserLibrary.Services;

public static class Validators
{
    public static string ValidateInput(string field)
    {
        string input;
        do
        {
            input = Console.ReadLine()!.Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"INVALID FORMAT: Please type in your {field}");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }
    
    public static string IsSame(string item, string errorText)
    {
        var doItemsMatch = false;
        string input;

        do
        {
            input = Console.ReadLine()!.Trim();
            if (input != item)
            {
                Console.WriteLine($"{errorText}");
            }
            else
            {
                doItemsMatch = true;
            }
        } while (!doItemsMatch);
        

        return input;
    }

    public static string ValidateWithRegex(string item, string errorText, string regexPattern)
    {
        var isValid = false;
        string input;
        
        Regex regex = new(regexPattern);

        do
        {
            input = Console.ReadLine()!.Trim();
            if (!regex.IsMatch(input))
            {
                Console.WriteLine($"{errorText}");
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        

        return input;
    }
    
}