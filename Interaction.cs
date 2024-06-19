namespace DMScreen;

internal static class Interactions
{
    internal static List<Interaction> List { get; set; } = [];

    internal static bool Loaded = false;

    internal static Interaction Next()
    {
        Interaction? interaction;
        if (List.Count == 1)
        {
            interaction = List[0];
        }
        else
        {
            NextIndex++;
            interaction = List[NextIndex % List.Count];
        }
        return interaction;
    }

    private static int NextIndex = 0;

    internal static void Reset()
    {
        List = [];
        Loaded = false;
        NextIndex = 0;
    }

    internal static void Add(string input)
    {
        List.Add(new Interaction(input));
    }
}

internal class Interaction
{
    internal Interaction(string input)
    {
        var parts = input.Split('d');
        if (parts.Length != 2)
        {
            Error = true;
            return;
        }
        NumberOfDice = int.Parse(parts[0]);
        TypeOfDice = int.Parse(parts[1]);
    }
    private int NumberOfDice { get; }
    private int TypeOfDice { get; }
    private bool Error { get; } = false;
    private List<int> Rolls { get; set; } = [];

    public bool HasRolled => Rolls.Count != 0;

    public void Roll()
    {
        if (Error || Rolls.Count != 0)
        {
            return;
        }
        for (var i = 0; i < NumberOfDice; i++)
        {
            var roll = TypeOfDice switch
            {
                100 => DiceRoller.RollD100(),
                20 => DiceRoller.RollD20(),
                12 => DiceRoller.RollD12(),
                10 => DiceRoller.RollD10(),
                8 => DiceRoller.RollD8(),
                6 => DiceRoller.RollD6(),
                4 => DiceRoller.RollD4(),
                _ => -1
            };
            Rolls.Add(roll);
        }
    }

    public string Value => Rolls.Count == 0 ? PreRoll : PostRoll;

    private string PreRoll => Error ? "ERROR" : $"{NumberOfDice}d{TypeOfDice}";

    private string PostRoll => $"{string.Join(" + ", Rolls)} = {Rolls.Sum()}";
}

internal enum InteractionType
{
    Dice,
    Damage
}
