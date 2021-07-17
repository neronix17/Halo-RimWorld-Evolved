using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using O21Toolbox;

namespace Halo
{
    public class HaloMod : Mod
    {
        public static HaloSettings settings;
        public static HaloMod mod;

        public HaloMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<HaloSettings>();
            mod = this;
        }

        public override string SettingsCategory()
        {
            return "Halo - RimWorld Evolved";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float secondStageHeight;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Note("Changing Factions requires a restart to take effect. You should NEVER disable options mid-save, it's the same as uninstalling that part of the mod and can have severe consequences, no support will be provided if you do this and if anything you'll be actively mocked for it.", GameFont.Small);
            listingStandard.GapLine();
            secondStageHeight = listingStandard.CurHeight;
            listingStandard.End();

            listingStandard = new Listing_Standard
            {
                ColumnWidth = (inRect.width - 30f) / 2f - 2f
            };
            inRect.yMin = secondStageHeight;
            listingStandard.Begin(inRect);
            listingStandard.Gap(48);

            listingStandard.CheckboxEnhanced("Human Content", "Toggles human content, the apparel, weapons, etc. which is used by the UNSC and Innies", ref settings.content_humans);
            if (settings.content_humans)
            {
                listingStandard.GapLine();
                listingStandard.CheckboxEnhanced("Faction: UNSC", "Human military force, comprised of marines and Spartans.", ref settings.faction_unsc);
                listingStandard.CheckboxEnhanced("Faction: Insurrectionists", "Human organisation for liberation from the UEG and UNSC.", ref settings.faction_innies);
            }
            listingStandard.GapLine(24f);

            listingStandard.CheckboxEnhanced("Covenant Content", "Toggles Covenant content, the races, apparel, weapons, etc. which is used by the Covenant and their splinter factions.", ref settings.content_covenant);
            //if (settings.content_covenant)
            //{
            //    listingStandard.GapLine();
            //    listingStandard.CheckboxEnhanced("Faction: Covenant Empire", "The Covenant Empire as led by the Prophets, comprised of various races.", ref settings.faction_covenant);
            //    listingStandard.CheckboxEnhanced("Faction: Swords of Sanghelios", "The Sangheili dominated Covenant splinter faction uses the usual Covenant Empire tech.", ref settings.faction_swords);
            //    listingStandard.CheckboxEnhanced("Faction: The Banished", "A Brute dominated Covenant splinter faction, they have a mix of other Covenant races along with using Covenant tech with their own twist to it.", ref settings.faction_banished);
            //}

            listingStandard.NewColumn();
            listingStandard.Gap(48);

            listingStandard.CheckboxEnhanced("Forerunner Content", "Toggles Forerunner content, which can appear in many ways, as ruins, incidents, world map events, etc.", ref settings.content_forerunner);
            //if (settings.content_forerunner)
            //{
            //    listingStandard.GapLine();
            //    listingStandard.CheckboxEnhanced("Faction: Sentinels", "Forerunner built systems, sentinels will fill any role they need to for them to keep the ancient technology running.", ref settings.faction_sentinels);
            //}
            //listingStandard.GapLine(24f);

            //listingStandard.CheckboxEnhanced("The Flood", "Toggles Flood content. This covers their hidden faction, the infection itself, and incidents related to them.", ref settings.content_flood);
            //listingStandard.Note("The flood are disabled by default since they are likely to overwhelm the unprepared. Scenarios are also unlocked with this option which is heavily suggested to make use of, they'll skip some earlier research you would usually have to do and give you some basic equipment to be able to hold off initial attacks. Unlike Mechanoids, Flood forms can and will show up quite early.", GameFont.Tiny);

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }

    public class HaloSettings : ModSettings
    {
        public bool content_humans = true;
        public bool faction_unsc = true;
        public bool faction_innies = true;

        public bool content_covenant = true;
        public bool faction_covenant = true;
        public bool faction_swords = true;
        public bool faction_banished = true;

        public bool content_forerunner = true;
        public bool faction_sentinels = true;

        public bool content_flood = false;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref content_humans, "content_humans", true);
            Scribe_Values.Look(ref faction_unsc, "faction_unsc", true);
            Scribe_Values.Look(ref faction_innies, "faction_innies", true);

            Scribe_Values.Look(ref content_covenant, "content_covenant", true);
            Scribe_Values.Look(ref faction_covenant, "faction_covenant", true);
            Scribe_Values.Look(ref faction_swords, "faction_swords", true);
            Scribe_Values.Look(ref faction_banished, "faction_banished", true);

            Scribe_Values.Look(ref content_forerunner, "content_forerunner", true);
            Scribe_Values.Look(ref faction_sentinels, "faction_sentinels", true);

            Scribe_Values.Look(ref content_flood, "content_flood", false);
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
