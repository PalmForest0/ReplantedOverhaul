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
            .Register();
    }

    // Config inputs used for testing BloomEngine
    // (Not currently relevant to the project)
    //public static readonly StringConfigInput StringInput = ConfigService.CreateString("Cool String Input", "Test Description", "ABCDEFG")
    //    .WithOnValueChanged(val => Melon<ReplantedOverhaulMod>.Logger.Msg($"Value of {nameof(StringInput)} updated to \"{val}\""))
    //    .WithOnInputChanged(() => StringInput.Textbox.SetTextWithoutNotify(StringInput.Textbox.text.ToUpperInvariant()))
    //    .WithTransformFunc(val => val.ToUpperInvariant())
    //    .WithValidateFunc(val => !string.IsNullOrWhiteSpace(val));

    //public static BoolConfigInput BoolInput { get; } = ConfigService.CreateBool("Test Bool ???", "Tired of writing descriptions", true)
    //    .WithOnValueChanged(val => Melon<ReplantedOverhaulMod>.Logger.Msg($"Value of {nameof(BoolInput)} updated to {val}"));

    //public static EnumConfigInput<TestEnum> EnumInput { get; } = ConfigService.CreateEnum(nameof(EnumInput), "desc", TestEnum.Option1)
    //    .WithOnValueChanged(val => MelonLogger.Msg($"Value of {nameof(EnumInput)} updated to {val}"))
    //    .WithValidateFunc(val => Enum.IsDefined(typeof(TestEnum), val));
    //enum TestEnum
    //{
    //    Option1,
    //    Option2,
    //    Option3,
    //    Option4,
    //    Option5
    //}
}