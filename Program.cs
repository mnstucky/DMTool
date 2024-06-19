using DMScreen;

var run = true;
var spells = Helpers.GetSpells();
if (spells is null)
{
    Environment.Exit(1);
}
var mode = Modes.Normal;
var input = "";
var spellSearch = new SpellSearch();

Console.WriteLine($"{ModesHelpers.GetFriendlyMode(mode)} > {input}");
Console.SetCursorPosition(input.Length + 4, 0);
while (run)
{
    var key = Console.ReadKey();
    if (mode == Modes.Normal)
    {
        switch (key.KeyChar)
        {
            case 's':
                mode = Modes.Spells;
                input = "";
                Interactions.Reset();
                break;
            case 'd':
                mode = Modes.Dice;
                input = "";
                Interactions.Reset();
                break;
        }
    }
    else
    {
        if (key.Key == ConsoleKey.Tab)
        {
            mode = Modes.Normal;
            input = "";
            Interactions.Reset();
        }
        if (key.Key == ConsoleKey.Backspace)
        {
            if (input.Length == 0)
            {
                continue;
            }
            input = input[..^1];
        }
        else
        {
            input += key.KeyChar;
        }
    }
    Console.Clear();
    Console.WriteLine($"{ModesHelpers.GetFriendlyMode(mode)} > {input}");
    switch (mode)
    {
        case Modes.Spells:
            spellSearch.PrintSpells(key.Key, input);
            break;
        case Modes.Dice:
            DiceRoller.PrintRoll(key.Key, input);
            input = "";
            break;
    }
    Console.SetCursorPosition(input.Length + 4, 0);
}
