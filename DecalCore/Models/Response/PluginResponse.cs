using System;
using Newtonsoft.Json;

namespace DecalCore.Models.Response;

[Serializable]
public class PluginResponse {
    [JsonProperty("plugin_id")]
    public string PluginId { get; set; }
    
    [JsonProperty("plugin_guid")]
    public string PluginGuid { get; set; }
    
    [JsonProperty("plugin_name")]
    public string PluginName { get; set; }
    
    [JsonProperty("plugin_version")]
    public string PluginVersion { get; set; }
}