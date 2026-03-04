using HarmonyLib;

namespace DecalCore.Extensions;

public static class ReflectionExtensions {
    extension(object target) {
        public void InvokeMethod(string methodName, params object[] methodParameters) => AccessTools.Method(target.GetType(), methodName).Invoke(target, methodParameters);
        public void SetField(string fieldName, object newValue) => AccessTools.Field(target.GetType(), fieldName).SetValue(target, newValue);
        public T GetField<T>(string fieldName) => (T)AccessTools.Field(target.GetType(), fieldName).GetValue(target);
    }
}