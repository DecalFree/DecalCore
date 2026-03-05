using GorillaNetworking;

namespace DecalCore.Extensions;

public static class NetPlayerExtensions {
    extension(NetPlayer netPlayer) {
        public string GetSanitizedNickName() {
            string freshPeerNickName = netPlayer.NickName;

            if (freshPeerNickName.Length > 0 && GorillaComputer.instance.CheckAutoBanListForName(freshPeerNickName)) {
                return freshPeerNickName.EnforceLength(12).ToUpper();
            }

            return "BADGORILLA";
        }
    }
}