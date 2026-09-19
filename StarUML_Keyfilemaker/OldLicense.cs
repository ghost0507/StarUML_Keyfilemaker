using Newtonsoft.Json;

namespace StarUML_Keyfilemaker
{
    public class OldLicense : License
    {
        [JsonProperty("licenseType")]
        public string LicenseType { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
