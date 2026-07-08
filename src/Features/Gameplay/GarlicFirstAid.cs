using Il2CppReloaded.Gameplay;
using Il2CppReloaded.Services;
using Il2CppSource.Controllers;
using ReplantedOverhaul.Utility;

namespace ReplantedOverhaul.Features.Gameplay;

/// <summary>
/// Allows garlic to be planted on another damaged garlic if Wallnut First-Aid has been purchased.
/// </summary>
internal static class GarlicFirstAid
{
    /// <summary>
    /// Allows garlic to be planted on another damaged garlic if Wallnut First-Aid has been purchased.
    /// </summary>
    /// <returns>True if the garlic can be repaired, false otherwise.</returns>
    public static bool TryRepairGarlic(Plant plant, SeedType newType)
    {
        // If the conditions for repairing the garlic are not met, return false
        if (!CanDoGarlicFirstAid(plant, newType))
            return false;

        // Emulate the lighter color overaly that is present when healing other wall plants
        plant.mController.SetEnableExtraAdditiveDraw(true, CharacterAnimationTrack.Body);
        plant.mController.SetExtraAdditiveColor(new UnityEngine.Color(1f, 1f, 1f, 0.769f), CharacterAnimationTrack.Body);

        // Allow the garlic to be placed on top of the existing garlic
        return true;
    }

    /// <summary>
    /// Checks if the player is trying to plant a Garlic on a tile that already has a Garlic,
    /// if they have purchased Wallnut First-Aid, and if the garlic is missing any health.
    /// </summary>
    private static bool CanDoGarlicFirstAid(Plant plant, SeedType newType)
    {
        if (!InstanceRegistry.TryGet<UserService>(out var service, logErrorIfNotFound: true)) // Check that the UserService is available (and log an error if not)
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
