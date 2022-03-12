using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using O21Toolbox;

namespace OutlandTerrain
{
    public class OutlandTerrainMod : Mod
    {
        public static OutlandTerrainMod mod;
        public static OutlandTerrainSettings settings;

        public Vector2 scrollPosition;

        public OutlandTerrainMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<OutlandTerrainSettings>();
            Log.Message(":: Outland - Terrain :: 1.0.0 ::");
        }

        public override string SettingsCategory() => "Outland - Terrain";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float secondStageHeight;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Note("Changing settings requires a restart, the adjustments had to be performed during startup.", GameFont.Tiny);
            listingStandard.GapLine();
            listingStandard.Gap(48);
            secondStageHeight = listingStandard.CurHeight;
            listingStandard.End();

            inRect.yMin = secondStageHeight;
            Rect outRect = inRect.ContractedBy(10f);

            float scrollRectHeight = 600f;
            Rect rect = new Rect(0f, 0f, outRect.width - (scrollRectHeight > outRect.height ? 18f : 0), scrollRectHeight);
            Widgets.BeginScrollView(outRect, ref scrollPosition, rect, true);
            listingStandard = new Listing_Standard();
            listingStandard.Begin(rect);

            listingStandard.CheckboxEnhanced("Grassy Soil & Moss", "Switches to the grassy textures for soil & moss, Comigo's Majestic Trees already does this function and both would need to be disabled for terrain to be not grassy.", ref settings.grassyTerrain);
            listingStandard.GapLine();

            listingStandard.End();
            Widgets.EndScrollView();

            base.DoSettingsWindowContents(inRect);
        }
    }
}
