using DMScreen;

var run = true;
var setupDone = SharedState.Setup();
if (!setupDone)
{
    Environment.Exit(1);
}

Console.WriteLine($"{ModesHelpers.GetFriendlyMode(SharedState.Mode)} > {SharedState.Input}");
Console.SetCursorPosition(SharedState.Input.Length + 4, 0);
while (run)
{
    var key = Console.ReadKey();
    if (SharedState.Mode == Modes.Normal)
    {
        switch (key.KeyChar)
        {
            case 's':
                SharedState.ToSpellMode();
                break;
            case 'd':
                SharedState.ToDiceMode();
                break;
        }
    }
    else
    {
        if (key.Key == ConsoleKey.Tab)
        {
            SharedState.ToNormalMode();
        }
        if (key.Key == ConsoleKey.Backspace)
        {
            if (input.Length == 0)
            
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
