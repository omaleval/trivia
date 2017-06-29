using System;
using Nancy.Hosting.Self;

namespace Trivia.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = "http://localhost:80/Temporary_Listen_Addresses/";
            using (var host = new NancyHost(new Uri(url)))
            {
                host.Start();
                Console.WriteLine("Running on " + url);
                Console.ReadLine();
            }
        }
    }
}
