using HarmonyLib;
using UnityEngine;
using Il2CppReloaded.Gameplay;
using BloomEngine.Helpers;
using Il2CppTekly.PanelViews;

namespace ReplantedOverhaul.Patches.Menu;

[HarmonyPatch]
internal static class ZenGardenPatches
{
    /// <summary>
    /// Moves the Tree of Wisdom height label to the top center of the screen when init is called.
    /// </summary>
    [HarmonyPatch(typeof(Challenge), nameof(Challenge.TreeOfWisdomInit))]
    [HarmonyPostfix]
    private static void Challenge_TreeOfWisdomInit_Postfix(Challenge __instance)
    {
        PanelView gameplayPanel = UIHelper.GameplayPanels.m_panels.FirstOrDefault(p => p.m_id == "gameplay");

        if(!gameplayPanel)
        {
            Log.Warn("Gameplay panel not found. Cannot apply Tree of Wisdom height label position fix.");
            return;
        }    

        RectTransform heightLabel = gameplayPanel.transform.Find("Canvas/Layout/Center/TreeOfWisdomSize").GetComponent<RectTransform>();

        heightLabel.offsetMin = Vector2.zero;
        heightLabel.offsetMax = Vector2.zero;
        heightLabel.pivot = new Vector2(0.5f, 1.0f);
        heightLabel.anchoredPosition = new Vector2(0f, -100f);
        heightLabel.sizeDelta = new Vector2(800f, 75f);

        Log.Info("Applied Tree of Wisdom height label position fix.");
    }
}
