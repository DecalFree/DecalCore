using MelonLoader;

namespace DecalCore.Tools;

internal static class Logging {
    public static void Info(object logContent) => MelonLogger.Msg(logContent);

    public static void Warning(object logContent) => MelonLogger.Warning(logContent);

    public static void Error(object logContent) => MelonLogger.Error(logContent);
}