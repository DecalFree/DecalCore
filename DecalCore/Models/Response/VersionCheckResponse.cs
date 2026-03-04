namespace DecalCore.Models.Response;

public class VersionCheckResponse(string version, bool isVersionOutdated = false) {
    public readonly string Version = version;

    public readonly bool IsVersionOutdated = isVersionOutdated;
}