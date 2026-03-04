using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DecalCore.Models.Response;
using MelonLoader;
using Newtonsoft.Json;
using Semver;
using UnityEngine;

namespace DecalCore.Behaviors;

public class NetService : MonoBehaviour {
    public static NetService Singleton { get; private set; }
    private bool _initialized;
    
    private readonly HttpClient _httpClient = new();

    private List<PluginResponse> _pluginData = [];
    
    private async void Start() {
        if (_initialized || Singleton != null && Singleton != this) {
            MelonLogger.Error("Failed to start initializing NetService");
            return;
        }
        Singleton = this;
        _initialized = true;

        _pluginData = await FetchPluginData();
        
        // TODO: Send a Notification with a 'notificationDuration' of 10f if version is outdated.
        VersionCheckResponse versionCheckResponse = CheckPluginVersion(Constants.Guid, DecalCore.MelonInfo.SemanticVersion);
        if (versionCheckResponse is { IsVersionOutdated: true }) {
            MelonLogger.Warning($"DecalCore version {versionCheckResponse.Version} is now available");
        }
        
        MelonLogger.Msg("Successfully ended initializing NetService");
    }
    
    private async Task<List<PluginResponse>> FetchPluginData() {
        using HttpRequestMessage httpRequest = new(HttpMethod.Get, $"{Constants.APIEndpoint}/plugins");
        
        using HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
        string json = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode) {
            MelonLogger.Msg("Successfully retrieved PluginData");
            return JsonConvert.DeserializeObject<List<PluginResponse>>(json);
        }
        
        GlobalErrorResponse errorResponse = JsonConvert.DeserializeObject<GlobalErrorResponse>(json);
        MelonLogger.Error($"Failed to retrieve PluginData: '{errorResponse.ErrorMessage}' with status '{errorResponse.ErrorStatus}'");
        return null;
    }

    public bool IsPluginDataValid() {
        if (_pluginData.IsNullOrEmpty()) {
            MelonLogger.Error("_pluginData is null / empty");
            return false;
        }
        
        return true;
    }
    
    public PluginResponse GetPlugin(string pluginGuid) => !IsPluginDataValid() ? null : _pluginData.Find(plugin => plugin.PluginGuid == pluginGuid);

    public VersionCheckResponse CheckPluginVersion(string pluginGuid, SemVersion versionInUse) {
        PluginResponse plugin = GetPlugin(pluginGuid);
        if (plugin == null)
            return null;

        if (!SemVersion.TryParse(plugin.PluginVersion, out SemVersion latestPluginVersion))
            return new VersionCheckResponse(plugin.PluginVersion);

        return latestPluginVersion > versionInUse ? new VersionCheckResponse(plugin.PluginVersion, true) : new VersionCheckResponse(plugin.PluginVersion);
    }
}