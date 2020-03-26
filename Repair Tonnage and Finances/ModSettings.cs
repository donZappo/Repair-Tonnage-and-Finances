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
        public float LocustRepairTechFactor = 1;
        public float LocustRepairCostFactor = 1;
        public float MassProducedRepairFactor = 0.5f;
    }
}
