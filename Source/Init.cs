using HarmonyLib;
using RimWorld;
using Verse;

namespace Blocky.Doors;

[StaticConstructorOnStartup]
public class Init
{
    static Init()
    {
        Harmony harmony = new Harmony("Blocky.Doors");
        harmony.PatchAll();
    }
}
