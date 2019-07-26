using Newtonsoft.Json;

namespace GeoRegisterApp.Models
{
    public class SendObjectResult
    {
        [JsonProperty("error")]
        public string error { get; set; }
        [JsonProperty("errorID")]
        public string errorID { get; set; }
        [JsonProperty("errorDesc")]
        public string errorDesc { get; set; }
        [JsonProperty("takerName")]
        public string userName { get; set; }
        [JsonProperty("takerSurname")]
        public string userSurname { get; set; }
        [JsonProperty("workingPlaceName")]
        public string workingPlaceName { get; set; }
        [JsonProperty("workingPlaceId")]
        public string workingPlaceId { get; set; }

    }
}
