using DMScreen.Models;
using System.Text.Json;

namespace DMScreen;
internal class SpellSearch
{
    private IEnumerable<Spell> Spells { get; set; } = [];

    private IEnumerable<Spell> FilteredSpells { get; set; } = [];

    internal SpellSearch()
    {
        Spells = Helpers.GetSpells();
        FilteredSpells = Spells;
    }

    internal void PrintSpells(ConsoleKey key, string input)
    {
        if (key == ConsoleKey.Backspace)
        {
            FilteredSpells = Spells.Where(spell => spell.Name?.StartsWith(input, StringComparison.CurrentCultureIgnoreCase) == true);
        }
        else if (key == ConsoleKey.D1 || key == ConsoleKey.D2 || key == ConsoleKey.D3 || key == ConsoleKey.D4 || key == ConsoleKey.D5 || key == ConsoleKey.D6 || key == ConsoleKey.D7 || key == ConsoleKey.D8 || key == ConsoleKey.D9)
        {
            Interactions.List[(char)key - '0' - 1].Roll();
        }
        else
        {
            FilteredSpells = FilteredSpells.Where(spell => spell.Name?.StartsWith(input, StringComparison.CurrentCultureIgnoreCase) == true);
        }
        if (FilteredSpells.Count() == 1)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FilteredSpells.First().Name);
            Console.ResetColor();
            Console.WriteLine($"Level: {FilteredSpells.First().Level}");
            Console.WriteLine($"Source: {FilteredSpells.First().Source} {FilteredSpells.First().Page}");
            Console.WriteLine($"Time: {string.Join(" | ", FilteredSpells.First().Time?.Select(time => $"{time.Number} {time.Unit}") ?? [])}");
            Console.WriteLine($"Range: {FilteredSpells.First().Range?.Distance?.Amount} {FilteredSpells.First().Range?.Distance?.Type}");
            foreach (var entry in FilteredSpells.First().Entries ?? [])
            {
                PrintFriendlyEntry(entry);
            }
            Interactions.Loaded = true;
        }
        else
        {
            foreach (var filteredSpell in FilteredSpells.Take(10))
            {
                Console.WriteLine(filteredSpell.Name);
            }
            Interactions.Reset();
        }
    }

    private static string PrintFriendlyEntry(object entry)
    {
        var stringEntry = entry.ToString() ?? "ERROR";
        if (stringEntry.Contains("\"type\": \"list\""))
        {
            var listEntries = JsonSerializer.Deserialize<EntryList>(stringEntry, Helpers.JsonOptions);
            foreach (var listEntry in listEntries?.Items ?? [])
            {
                PrintFriendlyLine(listEntry);
            }
        }
        else
        {
            PrintFriendlyLine(stringEntry);
        }
        return stringEntry;
    }

    private static void PrintFriendlyLine(string text)
    {
        var splitText = text.Split(['{', '}']);
        foreach (var section in splitText)
        {
            if (section.StartsWith('@'))
            {
                if (!Interactions.Loaded)
                {
                    Interactions.List.Add(new Interaction(section.Split(" ")[1]));
                }
                var interaction = Interactions.Next();
                if (interaction.HasRolled)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write(interaction.Value);
                Console.ResetColor();
            }
            else
            {
                Console.Write(section);
            }
        }
        Console.WriteLine();
    }
}
