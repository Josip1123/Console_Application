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
        var doPasswordsMatch = false;
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
                doPasswordsMatch = true;
            }
        } while (!doPasswordsMatch);
        

        return input;
    }
}