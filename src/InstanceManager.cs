using System.Runtime.CompilerServices;

namespace ReplantedOverhaul;

/// <summary>
/// Basic global instance manager for storing instances of important classes that are difficult to access otherwise.
/// </summary>
internal static class InstanceManager
{
    private static readonly Dictionary<Type, object> instances = new();

    /// <summary>
    /// Gets instance and throws if not found. Use TryGet to handle errors and logging.
    /// </summary>
    public static T Get<T>() where T : class
    {
        if (instances.TryGetValue(typeof(T), out var instance))
            return (T)instance;

        throw new InvalidOperationException($"No instance registered for {typeof(T).Name}");
    }

    /// <summary>
    /// Sets or updates a global instance. Logs whether it's a new registration or an update.
    /// </summary>
    public static void Set<T>(T instance) where T : class
    {
        var type = typeof(T);
        var isUpdate = instances.ContainsKey(type);

        instances[type] = instance;

        Log.Info(isUpdate
            ? $"InstanceManager: {type.Name} instance updated."
            : $"InstanceManager: {type.Name} instance registered.");
    }

    /// <summary>
    /// Attempts to get an instance and returns true if found. Optionally logs an error if not found, including caller info for easier debugging.
    /// </summary>
    public static bool TryGet<T>(
        out T instance,
        bool logErrorIfNotFound = false,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0
    ) where T : class
    {
        if (instances.TryGetValue(typeof(T), out var raw))
        {
            instance = (T)raw;
            return true;
        }

        if (logErrorIfNotFound)
            Log.Error($"InstanceManager: No instance found for {typeof(T).Name} when accessing from {callerName} in {callerFile}:{callerLine}");

        instance = null;
        return false;
    }
}