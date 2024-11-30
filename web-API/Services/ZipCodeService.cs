using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public static class ZipCodeService
{
    public static async Task FetchAndDisplayLocationInfo(string zipCode)
    {
        var apiUrl = $"https://api.zippopotam.us/us/{zipCode}";
        using var client = new HttpClient();

        try
        {
            var response = await client.GetStringAsync(apiUrl);
            var location = JsonSerializer.Deserialize<LocationInfo>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (location?.Places != null && location.Places.Length > 0)
            {
                var place = location.Places[0];
                Console.WriteLine($"Place Name: {place.PlaceName}");
                Console.WriteLine($"Latitude: {place.Latitude}");
                Console.WriteLine($"Longitude: {place.Longitude}");
            }
            else
            {
                Console.WriteLine("No location data found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching location info: {ex.Message}");
        }
    }
}
