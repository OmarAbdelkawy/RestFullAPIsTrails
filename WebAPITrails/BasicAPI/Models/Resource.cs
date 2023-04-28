using System.Text.Json.Serialization;

namespace BasicAPI.Models
{
    public abstract class Resource
    {

        [JsonPropertyOrder(-2)]
        public string Href { get; set; }
    }
}
