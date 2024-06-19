using DMScreen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMScreen
{
    internal class SharedState
    {
        internal static Modes Mode { get; set; } = Modes.Normal;

        internal static string Input { get; set; } = "";

        private SpellSearch SpellSearch { get; set; } = new();

        internal static IEnumerable<Spell> Spells { get; set; } = [];

        internal static void ToSpellMode()
        {
            Mode = Modes.Spells;
            Input = "";
            Interactions.Reset();
        }

        internal static void ToDiceMode()
        {
            Mode = Modes.Dice;
            Input = "";
            Interactions.Reset();
        }

        internal static void ToNormalMode()
        {
            Mode = Modes.Normal;
            Input = "";
            Interactions.Reset();
        }

        internal static bool Setup()
        {
            Spells = Helpers.GetSpells(); 
            if (Spells.Any())
            {
                return true;
            }
            return false;
        }
    }
}
