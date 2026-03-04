using System;
using System.IO;
using DecalCore.Bootstrapper;
using MelonLoader;
using MelonLoader.Utils;

[assembly: MelonInfo(typeof(DecalCoreBootstrapper), Constants.Name, Constants.Version, Constants.Author)]
[assembly: MelonGame("Another Axiom", "Gorilla Tag")]

namespace DecalCore.Bootstrapper;

internal class DecalCoreBootstrapper : MelonPlugin {
    public override void OnPreInitialization() {
        string modsFolder = Path.Combine(MelonEnvironment.GameRootDirectory, "Mods/Decal's Mods");

        foreach (string? melonMod in Directory.EnumerateFiles(modsFolder, "*.dll", SearchOption.TopDirectoryOnly)) {
            try {
                MelonAssembly? melonAssembly = MelonAssembly.LoadMelonAssembly(melonMod);
                if (melonAssembly == null) {
                    MelonLogger.Warning($"Failed to load {Path.GetFileName(melonMod)} MelonAssembly");
                    continue;
                }
                
                RegisterSorted(melonAssembly.LoadedMelons);
                MelonLogger.Msg($"Successfully loaded {Path.GetFileName(melonMod)} MelonAssembly");
            }
            catch (Exception exception) {
                MelonLogger.Error($"Failed to load {melonMod} MelonMod: {exception.Message}");
            }
        }
    }
}