using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Blocky.Doors;

// hide stuffable doors
[HarmonyPatch(typeof(Designator_Build), "get_Visible")]
static class Patch_HideStuffableDoors {
    static void Postfix( ref bool __result, BuildableDef ___entDef ){
        if( __result == false ) return;

        if( ___entDef.defName.StartsWith("Blocky_Doors_") && ___entDef.defName.EndsWith("_Stuffable") ){
            __result = ModConfig.Settings.showStuffable;
        }
    }
}
