using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Coordinates
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string appId = "SEU ID AQUI";

            Console.WriteLine("Digite uma cidade: ");
            string cidade = Console.ReadLine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage respon = await client.GetAsync("?q=" + cidade + "&APPID=" + appId + "&units=metric");

                if (respon.StatusCode == HttpStatusCode.OK)
                {
                    CoordenadasModel c = respon.Content.ReadAsAsync<CoordenadasModel>().Result;
                    Console.WriteLine("Latitude: " + c.coord.lat);
                    Console.WriteLine("Longitude: " + c.coord.lon);
                }
                Console.ReadKey();
            }
        }
    }
}
