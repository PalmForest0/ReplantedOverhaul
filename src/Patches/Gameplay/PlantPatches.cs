using HarmonyLib;
using Il2CppReloaded.Gameplay;
using ReplantedOverhaul.Features.Gameplay;

namespace ReplantedOverhaul.Patches.Gameplay;

[HarmonyPatch]
internal static class PlantPatches
{
    [HarmonyPatch(typeof(Plant), nameof(Plant.IsUpgradableTo))]
    [HarmonyPrefix]
    private static bool Plant_IsUpgradableTo_Prefix(Plant __instance, SeedType aUpdatedType, ref bool __result)
    {
        // If Garlic First Aid is enabled and the plant can be repaired, set the result of IsUpgradableTo to true and skip the original method.
        if (BloomConfig.GarlicFirstAid.Value && GarlicFirstAid.TryRepairGarlic(__instance, aUpdatedType))
        {
            __result = true;
            return false;
        }

        // Otherwise run original logic
        return true;
    }
}