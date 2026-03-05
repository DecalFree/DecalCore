using System;
using DecalCore.Behaviors;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;

[assembly: VerifyLoaderVersion(0, 7, 2, true)]

[assembly: MelonInfo(typeof(DecalCore.DecalCore), DecalCore.Constants.Name, DecalCore.Constants.Version, DecalCore.Constants.Author)]
[assembly: MelonGame("Another Axiom", "Gorilla Tag")]

namespace DecalCore;

internal class DecalCore : MelonMod {
    public static MelonInfoAttribute MelonInfo;
    
    public override void OnInitializeMelon() {
        MelonInfo = Info;
        
        GorillaTagger.OnPlayerSpawned(InitializeDecalCore);
    }

    private void InitializeDecalCore() {
        try {
            MelonLogger.Msg("Attempting to load DecalCore");
            
            Object.DontDestroyOnLoad(new GameObject($"DecalCore v{Constants.Version}", typeof(NetService), typeof(NetWave)));
        }
        catch (Exception exception) {
            MelonLogger.Error($"Failed to successfully finish loading DecalCore: {exception.Message}");
        }
    }
}