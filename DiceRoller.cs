namespace DMScreen;
internal class DiceRoller
{
    private static readonly Random _random = new();

    internal static int RollD100() => _random.Next(1, 21);

    internal static int RollD20() => _random.Next(1, 21);

    internal static int RollD12() => _random.Next(1, 13);

    internal static int RollD10() => _random.Next(1, 11);

    internal static int RollD8() => _random.Next(1, 9);

    internal static int RollD6() => _random.Next(1, 7);

    internal static int RollD4() => _random.Next(1, 5);

    private static string GetRollType(ConsoleKey key)
    {
        return key switch
        {
            ConsoleKey.D7 => "D100",
            ConsoleKey.D6 => "D20",
            ConsoleKey.D5 => "D12",
            ConsoleKey.D4 => "D10",
            ConsoleKey.D3 => "D8",
            ConsoleKey.D2 => "D6",
            ConsoleKey.D1 => "D4",
            _ => "ERROR"
        };
    }

    internal static void PrintRoll(ConsoleKey key, string input)
    {
        if (string.IsNullOrEmpty(input) || input == "d")
        {
            return;
        }
        var roll = key switch
        {
            ConsoleKey.D7 => RollD100(),
            ConsoleKey.D6 => RollD20(),
            ConsoleKey.D5 => RollD12(),
            ConsoleKey.D4 => RollD10(),
            ConsoleKey.D3 => RollD8(),
            ConsoleKey.D2 => RollD6(),
            ConsoleKey.D1 => RollD4(),
            _ => -1
        };
        Console.WriteLine($"{GetRollType(key)}: {roll}");
    }
}
