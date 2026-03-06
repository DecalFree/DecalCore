namespace DecalCore.Extensions;

public static class NetPlayerExtensions {
    extension(NetPlayer netPlayer) {
        public string GetSanitizedNickName() => VRRig.LocalPeerVRRig.NormalizeName(true, netPlayer.NickName);
    }
}