using BloomEngine.Config;
using BloomEngine.Config.Inputs;

namespace ReplantedOverhaul;

internal static class BloomConfig
{
    public static BoolConfigInput GarlicFirstAid { get; } = ConfigService.CreateBool(
        name:           "Garlic First aid", 
        defaultValue:   true, 
        description:    "Allows garlic to be planted on another damaged garlic to repair it if Wallnut First-Aid has been purchased."
    );

    public static BoolConfigInput TreeOfWisdomLabelFix { get; } = ConfigService.CreateBool(
        name:           "Tree of Wisdom Label Fix",
        defaultValue:   true,
        description:    "Moves the Tree of Wisdom height label to the top center of the screen in the zen garden."
    );
}
