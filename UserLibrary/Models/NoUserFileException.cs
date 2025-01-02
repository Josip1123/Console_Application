namespace UserLibrary.Models;

public class NoUserFileException : Exception
{
    public NoUserFileException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}