namespace DutyAppDB.Shared;

public static class Helpers
{
    public static void SuccessTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void FailureTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: {0}", text);
        Console.ResetColor();
    }

    public static void InfoTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
