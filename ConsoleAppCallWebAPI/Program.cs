using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
namespace ConsoleAppCallWebAPI
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            //  var stringTask = client.GetStringAsync("https://localhost:44373/api/Bieren");
            var stringTask = client.GetStringAsync("https://localhost:44373/api/Bieren");
            var msg = await stringTask;
            Console.Write(msg);
            Console.ReadKey();
        }
    }

}
