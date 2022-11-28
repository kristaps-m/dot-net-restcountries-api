using System.Text.Json.Serialization;

namespace Restcountries.Classes.Classes
{
    public class Country
    {
        public TheName? Name { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        [JsonPropertyName("tld")]
        public List<string>? TopLevelDomain { get; set; }
        public List<string>? Capital { get; set; }
    }
}
