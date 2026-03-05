using UnityEngine;

namespace DecalCore.Extensions;

public static class VRRigExtensions {
    extension(VRRig vrRig) {
        public int LocalPeerFPS() => Mathf.RoundToInt(1f / Time.smoothDeltaTime);
    }
}