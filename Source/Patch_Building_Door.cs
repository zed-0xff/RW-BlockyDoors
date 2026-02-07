using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Blocky.Doors;

// doors free rotation
#if RW15
[HarmonyPatch(typeof(DoorUtility), nameof(DoorUtility.DoorRotationAt))]
#else
[HarmonyPatch(typeof(Building_Door), nameof(Building_Door.DoorRotationAt))]
#endif
static class Patch_DoorRotationAt {
    static bool Prefix(ref Rot4 __result, IntVec3 loc, Map map){
        if( !ModConfig.Settings.freeRotation )
            return true;

        foreach( Thing t in loc.GetThingList(map) ){
            if( t is Building_Door && t.def.defName.StartsWith("Blocky_Doors") ){
                __result = t.Rotation; // keep existing rotation
                return false;
            }
            if( t is IConstructible c && t.def.entityDefToBuild.defName.StartsWith("Blocky_Doors") ){
                __result = t.Rotation; // keep existing rotation
                return false;
            }
        }

        return true;
    }
}
