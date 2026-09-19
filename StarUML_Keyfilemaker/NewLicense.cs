using Newtonsoft.Json;

namespace StarUML_Keyfilemaker
{
    public class NewLicense : License
    {
        [JsonProperty("edition")]
        public string Edition { get; set; }

        [JsonProperty("deviceId")]
        public string DelivceId { get; set; }
    }
}
