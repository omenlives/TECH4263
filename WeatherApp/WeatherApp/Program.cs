using System.Text.Json;

// ── Cities to look up ──────────────────────────────────────────────
string[] cities = { "Tokyo", "Cairo", "Toronto" };
string[] usCities = { "Memphis", "Indianapolis", "Chicago", "Anchorage", "Grayling" };

// ── Single shared HttpClient ───────────────────────────────────────
var httpClient = new HttpClient();

// ── Helper: convert weathercode to a description ───────────────────
// TODO: Expand this to cover at least 8 codes — see the table below
string GetWeatherDescription(int code) => code switch
{
    0 => "Clear Sky",
    1 or 2 => "Partly Cloudy",
    3 => "Overcast",
    _ => $"Code {code}"
};

// ── Helper: lookup one city (optionally force a country) ───────────
async Task LookupCityAsync(string city, string? countryCode = null)
{
    Console.WriteLine($"Looking up: {city}...");

    try
    {
        // If countryCode is provided, add it to reduce "wrong city" matches
        var geoUrl =
            $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(city)}&count=1" +
            (countryCode != null ? $"&country={countryCode}" : "");

        var geoResponse = await httpClient.GetAsync(geoUrl);

        if (!geoResponse.IsSuccessStatusCode)
        {
            Console.WriteLine($"  [!] Geocoding failed: {geoResponse.StatusCode}\n");
            return;
        }

        string geoJson = await geoResponse.Content.ReadAsStringAsync();
        using var geoDoc = JsonDocument.Parse(geoJson);

        if (!geoDoc.RootElement.TryGetProperty("results", out var results) || results.GetArrayLength() == 0)
        {
            Console.WriteLine($"  [!] City '{city}' not found.\n");
            return;
        }

        var location = results[0];
        string cityName = location.GetProperty("name").GetString()!;
        string country = location.GetProperty("country").GetString()!;
        double lat = location.GetProperty("latitude").GetDouble();
        double lon = location.GetProperty("longitude").GetDouble();

        Console.WriteLine($"  Found    : {cityName}, {country} ({lat}°N, {lon}°E)");

        // ── STEP 2: Weather API — coordinates → weather ────────────
        var weatherUrl =
            $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true";
        var weatherResponse = await httpClient.GetAsync(weatherUrl);

        if (!weatherResponse.IsSuccessStatusCode)
        {
            Console.WriteLine($"  [!] Weather request failed: {weatherResponse.StatusCode}\n");
            return;
        }

        string weatherJson = await weatherResponse.Content.ReadAsStringAsync();
        using var weatherDoc = JsonDocument.Parse(weatherJson);

        var current = weatherDoc.RootElement.GetProperty("current_weather");
        double temp = current.GetProperty("temperature").GetDouble();
        double wind = current.GetProperty("windspeed").GetDouble();
        int code = current.GetProperty("weathercode").GetInt32();

        Console.WriteLine($"  Weather  : Temp: {temp}°C  |  Wind: {wind} km/h  |  {GetWeatherDescription(code)}");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"  [!] Network error: {ex.Message}");
    }

    Console.WriteLine();
}

// ── Main program ───────────────────────────────────────────────────
Console.WriteLine("===================================");
Console.WriteLine("    CITY WEATHER LOOKUP");
Console.WriteLine("===================================\n");

// Non-US cities (no country forced)
foreach (var city in cities)
{
    await LookupCityAsync(city);
}

Console.WriteLine("===================================");
Console.WriteLine("    US CITY WEATHER");
Console.WriteLine("===================================\n");

// US cities (force US so it grabs the right one)
foreach (var city in usCities)
{
    await LookupCityAsync(city, "US");
}

Console.WriteLine("===================================");
Console.WriteLine("Done!");