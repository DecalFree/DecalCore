using UnityEngine;

namespace DecalCore.Extensions;

public static class VRRigExtensions {
    extension(VRRig vrRig) {
        public static VRRig LocalPeerVRRig => VRRig.LocalRig ?? GorillaTagger.Instance.offlineVRRig;
        
        public int LocalPeerFPS() => Mathf.RoundToInt(1f / Time.smoothDeltaTime);
    }
}