using ConsoleApp.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static async Task  Main(string[] args)
        {
            var person = new User() {username="ekremerturk" ,password="E12345e12345"};

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:8834/session";
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            using var client = new HttpClient(handler);
            var response = await  client.PostAsync(url, data);
           
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
