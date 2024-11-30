using System.Text.Json.Serialization;

public class LocationInfo
{
    [JsonPropertyName("places")]
    public Place[] Places { get; set; }
}

public class Place
{
    [JsonPropertyName("place name")]
    public string PlaceName { get; set; }

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }
}
