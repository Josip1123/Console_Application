namespace Console_Contact_App.Models;

public class NoUserFileException : Exception
{
    public NoUserFileException()
        : base("No user file was found.")
    {
    }

    public NoUserFileException(string message)
        : base(message)
    {
    }

    public NoUserFileException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}