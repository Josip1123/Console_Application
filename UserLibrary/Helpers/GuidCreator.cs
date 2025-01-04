namespace UserLibrary.Helpers;

public static class GuidCreator
{
    public static string CreateNewId()
    {
        return Guid.NewGuid().ToString();
    }
}