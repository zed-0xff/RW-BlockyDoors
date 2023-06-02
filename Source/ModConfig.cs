using System;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace Blocky.Doors;

public class Settings : Verse.ModSettings {
    public bool freeRotation;
    public bool showStuffable;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref freeRotation, "freeRotation", false);
        Scribe_Values.Look(ref showStuffable, "showStuffable", false);
        base.ExposeData();
    }
}

public class SettingsTab : Blocky.Core.SettingsTabBase {
    public override string Title => "Doors";

    public override void Draw(Listing_Standard l){
        l.CheckboxLabeled("Free rotation", ref ModConfig.Settings.freeRotation);
        l.CheckboxLabeled("Show stuffable doors", ref ModConfig.Settings.showStuffable);
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
