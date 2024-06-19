using DMScreen.Models;
using System.Text.Json;

namespace DMScreen;
internal static class Helpers
{
    internal static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };
    internal static IEnumerable<Spell> GetSpells()
    {
        var phb = File.ReadAllText("../../../Sources/spells-phb.json");
        var phbSpells = JsonSerializer.Deserialize<SpellFile>(phb, JsonOptions);
        var xge = File.ReadAllText("../../../Sources/spells-xge.json");
        var xgeSpells = JsonSerializer.Deserialize<SpellFile>(xge, JsonOptions);
        var tce = File.ReadAllText("../../../Sources/spells-tce.json");
        var tceSpells = JsonSerializer.Deserialize<SpellFile>(tce, JsonOptions);
        return (phbSpells?.Spell ?? []).Concat(xgeSpells?.Spell ?? []).Concat(tceSpells?.Spell ?? [])
            .OrderBy(spell => spell.Name);
    }
}
