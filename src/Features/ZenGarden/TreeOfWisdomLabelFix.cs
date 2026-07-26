using BloomEngine.Helpers;
using Il2CppTekly.PanelViews;
using UnityEngine;

namespace ReplantedOverhaul.Features.ZenGarden;

/// <summary>
/// Moves the Tree of Wisdom height label to the top center of the screen.
/// </summary>
internal static class TreeOfWisdomLabelFix
{
    public static void FindAndMoveLabel()
    {
        PanelView? gameplayPanel = UIHelper.GameplayPanels.m_panels.FirstOrDefault(p => p.m_id == "gameplay");

        if(!Log.Assert(gameplayPanel, "Gameplay panel not found. Cannot apply Tree of Wisdom label fix."))
            return;

        RectTransform heightLabel = gameplayPanel.transform.Find("Canvas/Layout/Center/TreeOfWisdomSize").GetComponent<RectTransform>();

        heightLabel.offsetMin = Vector2.zero;
        heightLabel.offsetMax = Vector2.zero;
        heightLabel.pivot = new Vector2(0.5f, 1.0f);
        heightLabel.anchoredPosition = new Vector2(0f, -100f);
        heightLabel.sizeDelta = new Vector2(800f, 75f);

        Log.Info("Applied Tree of Wisdom height label fix.");
    }
}