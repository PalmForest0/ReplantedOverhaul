using HarmonyLib;
using Il2CppReloaded.Services;

namespace ReplantedOverhaul.Patches.Instance;

[HarmonyPatch]
internal static class ServicePatches
{
    /// <summary>
    /// Set a global UserService instance for use in other patches.
    /// </summary>
    [HarmonyPatch(typeof(UserService), nameof(UserService.LoadProfileData))]
    [HarmonyPostfix]
    private static void UserService_LoadProfileData_Postfix(UserService __instance) => InstanceManager.Set(__instance);
}