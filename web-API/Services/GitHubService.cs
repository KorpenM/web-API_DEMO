using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public static class GitHubService
{
    public static async Task FetchAndDisplayRepositories()
    {
        var apiUrl = "https://api.github.com/orgs/dotnet/repos";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# App");

        try
        {
            var response = await client.GetStringAsync(apiUrl);
            var repos = JsonSerializer.Deserialize<List<GitHubRepo>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var repo in repos)
            {
                Console.WriteLine($"Name: {repo.Name}");
                Console.WriteLine($"Homepage: {repo.Homepage}");
                Console.WriteLine($"GitHub: {repo.HtmlUrl}");
                Console.WriteLine($"Description: {repo.Description}");
                Console.WriteLine($"Watchers: {repo.Watchers}");
                //Console.WriteLine($"Last push: {repo.PushedAt}");
                Console.WriteLine($"Last push: {repo.PushedAt:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching GitHub repositories: {ex.Message}");
        }
    }
}
