using System;
using System.IO;
using DecalCore.Bootstrapper;
using MelonLoader;
using MelonLoader.Utils;

[assembly: VerifyLoaderVersion(0, 7, 2, true)]

[assembly: MelonInfo(typeof(DecalCoreBootstrapper), Constants.Name, Constants.Version, Constants.Author)]
[assembly: MelonGame("Another Axiom", "Gorilla Tag")]

namespace DecalCore.Bootstrapper;

// This is really only meant for my development environment.
// But this is also for organization with different Melons being in different directories.
internal class DecalCoreBootstrapper : MelonPlugin {
    public override void OnPreInitialization() {
        foreach (string? additionalDirectory in Directory.EnumerateDirectories(MelonEnvironment.ModsDirectory)) {
            foreach (string? melonMod in Directory.EnumerateFiles(additionalDirectory, "*.dll", SearchOption.AllDirectories)) {
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
}