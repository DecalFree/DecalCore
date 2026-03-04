using System.Collections.Generic;
using DecalCore.Extensions;
using DecalCore.Models;
using GorillaNetworking;
using GorillaTag.CosmeticSystem;
using HarmonyLib;

namespace DecalCore.Patches;

[HarmonyPatch(typeof(VRRig))]
internal static class PatchVRRig {
    [HarmonyPatch("IUserCosmeticsCallback.OnGetUserCosmetics"), HarmonyPostfix]
    private static void OnPeerCosmeticsAchieved(VRRig __instance) {
        HashSet<string> freshPeerCosmetics = __instance.GetField<HashSet<string>>("_playerOwnedCosmetics");
        
        Dictionary<string, string> cleanPeerCosmetics = new();
        foreach (string cosmeticId in freshPeerCosmetics) {
            CosmeticsController.instance.TryGetCosmeticInfoV2(cosmeticId, out CosmeticInfoV2 cosmeticInfo);
            cleanPeerCosmetics.Add(cosmeticId, cosmeticInfo.displayName);
        }
        Events.Invoke_OnPeerCosmeticsAchieved(__instance.Creator ?? __instance.OwningNetPlayer, cleanPeerCosmetics);
    }
}