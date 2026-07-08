using HarmonyLib;
using Il2CppReloaded.Gameplay;
using ReplantedOverhaul.Features.ZenGarden;

namespace ReplantedOverhaul.Patches.Gameplay;

[HarmonyPatch]
internal static class ChallengePatches
{
    [HarmonyPatch(typeof(Challenge), nameof(Challenge.TreeOfWisdomInit))]
    [HarmonyPostfix]
    private static void Challenge_TreeOfWisdomInit_Postfix(Challenge __instance)
    {
        if(BloomConfig.TreeOfWisdomLabelFix.Value)
            TreeOfWisdomLabelFix.FindAndMoveLabel();
    }
}
