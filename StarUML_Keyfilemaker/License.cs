using Newtonsoft.Json;

namespace StarUML_Keyfilemaker
{
    public class License
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("licenseKey")]
        public string LicenseKey { get; set; }
    }
}
