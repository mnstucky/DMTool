namespace DMScreen.Models;

public class SpellFile
{
    public List<Spell>? Spell { get; set; }
}

public class Spell
{
    public string? Name { get; set; }
    public string? Source { get; set; }
    public int Page { get; set; }
    public int Level { get; set; }
    public string? School { get; set; }
    public List<Time>? Time { get; set; }
    public Range? Range { get; set; }
    public Components? Components { get; set; }
    //public List<Duration>? Duration { get; set; }
    //public Meta? Meta { get; set; }
    public List<object>? Entries { get; set; }
    //public List<string>? AreaTags { get; set; }
}

public class EntryList
{
    public string? Type { get; set; }
    public List<string>? Items { get; set; }
}

public class Time
{
    public int Number { get; set; }
    public string? Unit { get; set; }
}

public class Range
{
    public string? Type { get; set; }
    public Distance? Distance { get; set; }
}

public class Distance
{
    public string? Type { get; set; }
    public int Amount { get; set; }
}

public class Components
{
    public bool? V { get; set; }
    public bool? S { get; set; }
    public object? M { get; set; }
}

public class Duration
{
    public string? Type { get; set; }
    public DurationDetail? DurationDetail { get; set; }
}

public class DurationDetail
{
    public string? Type { get; set; }
    public int Amount { get; set; }
}

public class Meta
{
    public bool Ritual { get; set; }
}
