namespace DMScreen.Models;

public class NameFile
{
    public List<NameCollection>? Name { get; set; }
}

public class NameCollection
{
    public string? Name { get; set; }


}

public class NameTables
{
    public string? Option { get; set; }

    public string? DiceExpression { get; set; }
}

public class NameTable
{
    public List<NameResult>? Tables { get; set; }
}

public class NameResult
{
    public int? Min { get; set; }

    public int? Max { get; set; }

    public string? Result { get; set; }
}
