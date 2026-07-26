using HarmonyLib;
using Il2CppReloaded.Gameplay;
using ReplantedOverhaul.Features.Gameplay;

namespace ReplantedOverhaul.Patches.Gameplay;

[HarmonyPatch]
internal static class BoardPatches
{
    [HarmonyPatch(typeof(Board), nameof(Board.MouseDown))]
    [HarmonyPostfix]
    private static void Board_MouseDown_Postfix(Board __instance, int x, int y, int theClickCount, int playerIndex)
    {
        if (BloomConfig.DroppedSeedPacketFix.Value)
            SeedPacketCoinBoundsFix.TryClickFirstSeedPacketMargin(__instance, x, y, theClickCount, playerIndex);
    }
}
