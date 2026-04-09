using MelonLoader;
using MelonLoader.Logging;

namespace ReplantedOverhaul;

internal static class Log
{
    private static MelonLogger.Instance logger;

    internal static void Init(MelonLogger.Instance logger) => Log.logger = logger;

    public static void Debug(string msg, string prefix = "")
    {
#if DEBUG
        logger?.Msg(ColorARGB.Gray, $"{prefix}{msg}");
#endif
    }

    public static void Info(string msg, string prefix = "") => logger?.Msg($"{prefix}{msg}");
    public static void Warn(string msg, string prefix = "") => logger?.Warning($"{prefix}{msg}");
    public static void Error(string msg, string prefix = "") => logger?.Error($"{prefix}{msg}");
}