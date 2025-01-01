namespace Console_Contact_App.Models;

public class NoUserFileException : Exception
{
    public NoUserFileException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}