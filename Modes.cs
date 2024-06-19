using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMScreen;
internal enum Modes
{
    Normal,
    Dice,
    Spells
}

internal static class ModesHelpers
{
    internal static string GetFriendlyMode(Modes mode) => mode switch
    {
        Modes.Normal => "N",
        Modes.Dice => "D",
        Modes.Spells => "S",
        _ => " "
    };
}
