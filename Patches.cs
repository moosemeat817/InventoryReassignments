using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using HarmonyLib;
using MelonLoader;
using Il2CppTLD.Gear;

namespace InventoryReassignments
{
    public class Patches
    {
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        [HarmonyPriority(Priority.Last)]
        public class Reassignments
        {
            public static void Postfix(GearItem __instance)
            {
                // Normalize the name to strip "(Clone)" and whitespace
                string cleanName = __instance.name.Replace("(Clone)", "").Trim();

                     HashSet<string> materialNames = new()
                {
                    "GEAR_ArrowHead",
                    "GEAR_ArrowShaft",
                    "GEAR_BrokenArrow",
                    "GEAR_BrokenArrowHardened",
                    "GEAR_CarBattery",
                    "GEAR_Fuse",
                    "GEAR_GoldNugget",
                    "GEAR_Hook",
                    "GEAR_Line",
                    "GEAR_RevolverAmmoCasing",
                    "GEAR_RifleAmmoCasing",
                    "GEAR_SpearHead",
                    "GEAR_WireBundle"

                };


                    HashSet<string> flaskNames = new()
                {
                    "GEAR_InsulatedFlask_A",
                    "GEAR_InsulatedFlask_B",
                    "GEAR_InsulatedFlask_C",
                    "GEAR_InsulatedFlask_D",
                    "GEAR_InsulatedFlask_E",
                    "GEAR_InsulatedFlask_F",
                    "GEAR_InsulatedFlask_G"
                };


                    HashSet<string> teaNames = new()
                {
                    "GEAR_AcornCoffeeCup",
                    "GEAR_AcornGrounds",
                    "GEAR_BirchbarkTea",
                    "GEAR_BurdockTea",
                    "GEAR_CoffeeCup",
                    "GEAR_CoffeeTin",
                    "GEAR_GreenTeaCup",
                    "GEAR_GreenTeaPackage",
                    "GEAR_ReishiTea",
                    "GEAR_RoseHipTea"
                };


                    HashSet<string> foodNames = new()
                {
                    "GEAR_AcornShelled",
                    "GEAR_AcornShelledBig",
                    "GEAR_BurdockPrepared"
                };


                HashSet<string> toolNames = new()
                {
                    "GEAR_Canister",
                    "GEAR_Respirator",
                    "GEAR_HeatPad"
                };


                HashSet<string> accelerantNames = new()
                {
                    "GEAR_GunpowderCan",
                    "GEAR_LampFuel",
                    "GEAR_LampFuelFull"
                };



                if (materialNames.Contains(cleanName))
                {
                    __instance.GearItemData.m_Type = GearType.Material;
                }
                else if (foodNames.Contains(cleanName))
                {
                    __instance.GearItemData.m_Type = GearType.Food;
                }
                else if (toolNames.Contains(cleanName))
                {
                    __instance.GearItemData.m_Type = GearType.Tool;
                }


                else if (flaskNames.Contains(cleanName))
                {                   
                    switch (Settings.options.flasksMove)
                    {
                        case 0:
                            //__instance.GearItemData.m_Type = GearType.Tool;
                            break;
                        case 1:
                            __instance.GearItemData.m_Type = GearType.FirstAid;
                            break;
                        case 2:
                            __instance.GearItemData.m_Type = GearType.Food; 
                            break;
                        case 3:
                            __instance.GearItemData.m_Type = GearType.FirstAid | GearType.Tool;
                            break;
                        case 4:
                            __instance.GearItemData.m_Type = GearType.Food | GearType.Tool;
                            break;
                        case 5:
                            __instance.GearItemData.m_Type = GearType.Food | GearType.Tool | GearType.FirstAid;
                            break;
                    }
                }

                else if (teaNames.Contains(cleanName))
                {
                    switch (Settings.options.teasMove)
                    {
                        case 0:
                            //__instance.GearItemData.m_Type = GearType.Tool;
                            break;
                        case 1:
                            __instance.GearItemData.m_Type = GearType.FirstAid;
                            break;
                        case 2:
                            __instance.GearItemData.m_Type = GearType.Food;
                            break;
                        case 3:
                            __instance.GearItemData.m_Type = GearType.FirstAid | GearType.Food;
                            break;
                    }
                }

                else if (accelerantNames.Contains(cleanName))
                {
                    switch (Settings.options.accelerrantsMove)
                    {
                        case 0:
                            //__instance.GearItemData.m_Type = GearType.Tool;
                            break;
                        case 1:
                            __instance.GearItemData.m_Type = GearType.Firestarting;
                            break;
                        case 2:
                            __instance.GearItemData.m_Type = GearType.Firestarting | GearType.Tool;
                            break;
                    }
                }

            }
        }
    }

}