using System.Collections.Generic;
using BattleTech;

namespace Repair_Tonnage
{
    public class ModSettings
    {
        public bool Debug = false;
        public string modDirectory;
        public bool CBillsScale = false;

        public bool QuirksEnabled = false;
        public float LocustRepairFactor = 0.25f;
        public float MassProducedRepairFactor = 0.5f;
        public float ObsoleteRepairFactor = 1.25f;
        public float ShoddyRepairFactor = 1.5f;
        public float RareRepairFactor = 2.0f;
        public float MuseumItemRepairFactor = 3.0f;
    }
}
