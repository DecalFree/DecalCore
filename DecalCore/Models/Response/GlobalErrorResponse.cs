using System;
using Newtonsoft.Json;

namespace DecalCore.Models.Response;

[Serializable]
public class GlobalErrorResponse {
    [JsonProperty("message")]
    public string ErrorMessage { get; set; }
    
    [JsonProperty("status")]
    public string ErrorStatus { get; set; }
}