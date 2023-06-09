using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Blocky.Doors;

[StaticConstructorOnStartup]
public class CompRotatable : ThingComp
{
	CompProperties_Rotatable Props => (CompProperties_Rotatable)props;

    static readonly Texture2D RotateIcon = ContentFinder<Texture2D>.Get("Blocky/UI/Rotate", true);

    public override IEnumerable<Gizmo> CompGetGizmosExtra() {
        if( ModConfig.Settings.freeRotation ){
            yield return new Command_Action() {
                action = delegate{ parent.Rotation = parent.Rotation.Rotated(RotationDirection.Counterclockwise); },
                       hotKey = KeyBindingDefOf.Designator_RotateLeft, // Q
                       defaultLabel = "Rotate",
                       icon = RotateIcon
            };
        }
    }
}
