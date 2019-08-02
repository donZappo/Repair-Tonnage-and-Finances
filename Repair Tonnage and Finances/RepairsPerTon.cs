using System;
using BattleTech;
using Harmony;
using UnityEngine;

namespace Repair_Tonnage
{
    internal class RepairsPerTon
    {
        [HarmonyPatch(typeof(SimGameState), "CreateMechRepairWorkOrder", null)]
        public static class SimGameState_CreateMechRepairWorkOrder
        {
            private static void Prefix(ref SimGameState __instance, string mechSimGameUID, ChassisLocations location, int structureCount)
            {
                try
                {
                    RPTData.zscm = 1f;
                    RPTData.zstm = 1f;
                    RPTData.lastrepairstate = __instance;
                    foreach (MechDef mechDef in __instance.ActiveMechs.Values)
                    {
                        if (mechDef.GUID == mechSimGameUID)
                        {
                            float num = mechDef.Chassis.Tonnage;
                            if (num > 60f)
                            {
                                num = num * num / 60f;
                            }
                            if (mechDef.GetChassisLocationDef(location).InternalStructure == (float)structureCount)
                            {
                                RPTData.zscm = num * __instance.Constants.MechLab.ZeroStructureCBillModifier;
                                RPTData.zstm = num * __instance.Constants.MechLab.ZeroStructureTechPointModifier;
                                break;
                            }
                            RPTData.zscm = num;
                            RPTData.zstm = num;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }

        [HarmonyPatch(typeof(WorkOrderEntry_RepairMechStructure), MethodType.Constructor)]
        [HarmonyPatch(new Type[]
        {
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(int),
            typeof(ChassisLocations),
            typeof(int),
            typeof(int),
            typeof(string)
        })]
        public static class WorkOrderEntry_RepairMechStructure_ctor
        {
            private static void Prefix(ref int cbillCost, ref int techCost, int structureAmount)
            {
                try
                {
                    float num = (float)RPTData.lastrepairstate.Constants.MechLab.StructureRepairCost * (float)structureAmount;
                    float num2 = RPTData.lastrepairstate.Constants.MechLab.StructureRepairTechPoints * (float)structureAmount;
                    num *= RPTData.zscm;
                    num2 *= RPTData.zstm;
                    if (Core.Settings.CBillsScale)
                        cbillCost = Mathf.CeilToInt(num);

                    techCost = Mathf.CeilToInt(num2);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }
    }
}