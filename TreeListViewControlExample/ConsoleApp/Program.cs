using EntityFramework.Utilities.Generators;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Press enter key to populate database with seed data");
        var _initializeTableData = new InitializeTableData();
    }
}