//using HarmonyLib;
//using Il2CppReloaded.Gameplay;

//namespace PvZEnhanced.Patches;

//[HarmonyPatch(typeof(Board))]
//static internal class BoardPatches
//{
//    [HarmonyPatch(nameof(Board.AddSunMoney))]
//    [HarmonyPrefix]
//    private static void AddSun(ref int theAmount)
//    {
//        theAmount = theAmount switch
//        {
//            15 => 25,
//            50 => 100,
//            _ => 50
//        };
//    }

//    [HarmonyPatch(nameof(Board.AddPlant))]
//    [HarmonyPostfix]
//    private static void AddPlant(Board __instance, int theGridX, int theGridY, SeedType theSeedType, SeedType theImitaterType)
//    {
//        if (!__instance.PlantingRequirementsMet(theSeedType))
//            return;

//        if (theSeedType == SeedType.Gatlingpea)
//            __instance.NewPlant(theGridX, theGridY, theSeedType, theImitaterType);
//    }
//}