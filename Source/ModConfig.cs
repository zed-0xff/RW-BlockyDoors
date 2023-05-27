using System;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace Blocky.Doors;

public class Settings : Verse.ModSettings {
    public bool freeRotation;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref freeRotation, "freeRotation", false);
        base.ExposeData();
    }
}

public class SettingsTab : Blocky.Props.SettingsTabBase {
    public override string Title => "Doors";

    public override void Draw(Listing_Standard l){
        l.CheckboxLabeled("Free rotation", ref ModConfig.Settings.freeRotation);
    }

    public override void Write(){
        ModConfig.Settings.Write();
    }
}

public class ModConfig : Mod {
    public static Settings Settings { get; private set; }

    public ModConfig(ModContentPack content) : base(content) {
        Settings = GetSettings<Settings>();
    }
}
