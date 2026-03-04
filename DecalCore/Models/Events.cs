using System.Collections.Generic;

namespace DecalCore.Models;

public static class Events {
    public static event OnPeerCosmeticsAchieved_Handler OnPeerCosmeticsAchieved;
    
    public static event OnPeerCustomPropertiesAchieved_Handler OnPeerCustomPropertiesAchieved;

    #region Event Handler

    public delegate void OnPeerCosmeticsAchieved_Handler(NetPlayer netPlayer, Dictionary<string, string> peerCosmetics);
    
    public delegate void OnPeerCustomPropertiesAchieved_Handler(NetPlayer netPlayer, Dictionary<string, object> peerCustomProperties);

    #endregion

    #region Event Invokes

    internal static void Invoke_OnPeerCosmeticsAchieved(NetPlayer netPlayer, Dictionary<string, string> achievedPeerCosmetics) => OnPeerCosmeticsAchieved?.Invoke(netPlayer, achievedPeerCosmetics);
    
    internal static void Invoke_OnPeerCustomPropertiesAchieved(NetPlayer netPlayer, Dictionary<string, object> achievedPeerCustomProperties) => OnPeerCustomPropertiesAchieved?.Invoke(netPlayer, achievedPeerCustomProperties);

    #endregion
}