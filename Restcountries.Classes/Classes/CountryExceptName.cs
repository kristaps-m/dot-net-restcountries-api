using System.Text.Json.Serialization;

namespace dot_net_restcountries_api.Classes
{
    public class CountryExceptName
    {
        public double Area { get; set; }
        public int Population { get; set; }
        [JsonPropertyName("tld")]
        public List<string>? TopLevelDomain { get; set; }
        public List<string>? Capital { get; set; }
        public string? CommonNativeName { get; set; }
    }
}
