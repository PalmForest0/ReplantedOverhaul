using HarmonyLib;
using Il2CppReloaded.Gameplay;
using Il2CppReloaded.Services;

namespace ReplantedOverhaul.Patches.Gameplay;

[HarmonyPatch]
internal static class BoardPatches
{
    /// <summary>
    /// Allows garlic to be planted on another damaged garlic if Wallnut First-Aid has been purchased.
    /// </summary>
    [HarmonyPatch(typeof(Plant), nameof(Plant.IsUpgradableTo))]
    [HarmonyPrefix]
    private static bool Plant_IsUpgradableTo_Prefix(Plant __instance, SeedType aUpdatedType, ref bool __result)
    {
        if(CanDoGarlicFirstAid(__instance, aUpdatedType))
        {
            __result = true;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the player is trying to plant a Garlic on a tile that already has a Garlic,
    /// if they have purchased Wallnut First-Aid, and if the garlic is missing any health.
    /// </summary>
    private static bool CanDoGarlicFirstAid(Plant plant, SeedType newType)
    {
        if (!InstanceManager.TryGet<UserService>(out var service, logErrorIfNotFound: true)) // Check that the UserService is available (and log an error if not)
            return false;
        if (service.GetPurchases(StoreItem.Firstaid) <= 0) // Check that the user has purchased Wallnut First-Aid
            return false;
        if (newType != SeedType.Garlic) // Check if trying to plant a garlic
            return false;
        if (plant is null || plant.mSeedType != SeedType.Garlic) // Check if there's a garlic already there
            return false;
        if (plant.mPlantHealth >= plant.mPlantMaxHealth) // Check if the garlic is missing health
            return false;

        return true; // All conditions met :D
    }
}