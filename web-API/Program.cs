using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching GitHub repositories...");
        await GitHubService.FetchAndDisplayRepositories();

        Console.WriteLine("\nFetching location information...");
        await ZipCodeService.FetchAndDisplayLocationInfo("07645");



        Console.ReadKey();
    }
}
