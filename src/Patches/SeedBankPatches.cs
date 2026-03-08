using HarmonyLib;
using Il2CppReloaded.DataModels;
using Il2CppReloaded.Gameplay;
using MelonLoader;

namespace PvZEnhanced.Patches;

[HarmonyPatch]
internal static class SeedBankPatches
{
    //[HarmonyPatch(typeof(SeedBankEntryModel), nameof(SeedBankEntryModel.BoardHasPlants))]
    //[HarmonyPostfix]
    //private static void SeedBankEntryModel_BoardHasPlants_Postfix(SeedBankEntryModel __instance, SeedType type, ref bool __result)
    //{
    //    if (__result)
    //        return;

    //    __result = type switch
    //    {
    //        SeedType.Twinsunflower => true,
    //        _ => false,
    //    };
    //}

    [HarmonyPatch(typeof(SeedBankEntryModel), nameof(SeedBankEntryModel.HasUpgradeablePlants))]
    [HarmonyPostfix]
    private static bool SeedBankEntryModel_HasUpgradeablePlants_Postfix(bool hasUpgradeablePlants) => true;
}