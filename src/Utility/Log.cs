using MelonLoader;
using MelonLoader.Logging;
using System.Diagnostics.CodeAnalysis;

namespace ReplantedOverhaul;

internal static class Log
{
    private static MelonLogger.Instance logger;

    internal static void Init(MelonLogger.Instance logger) => Log.logger = logger;

    public static void Debug(string msg, string prefix = "")
    {
#if DEBUG
        logger?.Msg(ColorARGB.Gray, prefix + msg);
#endif
    }

    public static void Info(string msg, string prefix = "") => logger?.Msg(prefix + msg);
    public static void Warn(string msg, string prefix = "") => logger?.Warning(prefix + msg);
    public static void Error(string msg, string prefix = "") => logger?.Error(prefix + msg);

    // Returns true if assert passed, false if failed
    public static bool Assert([NotNullWhen(true)] bool condition, string msg, string prefix = "", bool warnInsteadOfError = false)
    {
        if (condition)
            return true;

        if (warnInsteadOfError)
            logger?.Warning(prefix + msg);
        else logger?.Error(prefix + msg);

        return false;
    }
}