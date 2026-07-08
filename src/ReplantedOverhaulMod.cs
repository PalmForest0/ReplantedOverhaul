using BloomEngine.ModMenu;
using MelonLoader;
using ReplantedOverhaul;

[assembly: MelonInfo(typeof(ReplantedOverhaulMod), ReplantedOverhaulMod.Name, ReplantedOverhaulMod.Version, ReplantedOverhaulMod.Author)]
[assembly: MelonGame("PopCap Games", "PvZ Replanted")]
[assembly: MelonOptionalDependencies("BloomEngine")]

namespace ReplantedOverhaul;

public class ReplantedOverhaulMod : MelonMod
{
    public const string Name = "Replanted Overhaul";
    public const string Description = "Overhauls PvZ: Replanted.";
    public const string Version = "0.1.0";
    public const string Author = "PalmForest";

    public override void OnInitializeMelon()
    {
        Log.Init(LoggerInstance);

        ModMenuService.CreateEntry(this)
            .AddDisplayName(Name)
            .AddDescription(Description)
            .AddConfigClass(typeof(BloomConfig))
            .Register();
    }
}