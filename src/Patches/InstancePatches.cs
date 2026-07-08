using HarmonyLib;
using Il2CppReloaded.Services;
using ReplantedOverhaul.Utility;
//using Il2CppReloaded.TreeStateActivities;

namespace ReplantedOverhaul.Patches;

[HarmonyPatch]
internal static class InstancePatches
{
    /// <summary>
    /// Set a global UserService instance for use in other patches.
    /// </summary>
    [HarmonyPatch(typeof(UserService), nameof(UserService.LoadProfileData))]
    [HarmonyPostfix]
    private static void UserService_LoadProfileData_Postfix(UserService __instance) => InstanceRegistry.Set(__instance);

    //[HarmonyPatch(typeof(GameplayActivity), nameof(GameplayActivity.Awake))]
    //[HarmonyPostfix]
    //private static void GameplayActivity_Awake_Postfix(GameplayActivity __instance) => InstanceManager.Set(__instance);
}