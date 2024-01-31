using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace HttpClient_C_Sharp
{
    class Program
    {
        public static string fileOutput = @"C:\VisualStudioCode\C#\HttpClient-C-Sharp\output.txt";
        static void Main(string[] args)
        {
            Console.Write("Describe a URL of the pagin: ");
            string url = Console.ReadLine();
            var awaiter = CallURL(url);

            if (awaiter.Result != "")
            {

                File.WriteAllText(fileOutput, awaiter.Result);
                Console.WriteLine("HTML response output to " + fileOutput);

            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static async Task<string> CallURL(string? url)
        {
            HttpClient client = new HttpClient();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}