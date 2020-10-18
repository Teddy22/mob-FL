using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Agile_Html
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://www.jumia.co.ke";
            var web = new HtmlWeb();

            int CurrentPage = 0;

            void SeeLaptopsFromPage(string Page) {
                
                var LaptopDocument = web.Load($"{url}/laptops/?page={Page}");
                HtmlNode[] LaptopsOnPage = LaptopDocument.DocumentNode.SelectNodes("//*[@class='core']").ToArray();

                foreach(HtmlNode LaptopOnPage in LaptopsOnPage)
                {
                    Console.WriteLine(LaptopOnPage.InnerText);
                }

            }

            SeeLaptopsFromName("Dell");

            void SeeLaptopsFromName(string Name)
            {
                var LaptopDocument = web.Load($"{url}/laptops/{Name}");
                HtmlNode[] Laptops = LaptopDocument.DocumentNode.SelectNodes("//*[@class='core']").ToArray();

                foreach(HtmlNode Laptop in Laptops)
                {
                    Console.WriteLine(Laptop.InnerText);
                }

            }
            
            void NextPage()
            {

                Console.BackgroundColor = ConsoleColor.Gray;

                var LaptopDocument = web.Load($"{url}/laptops/?page={CurrentPage}");
                CurrentPage += 1;
                HtmlNode[] Laptops = LaptopDocument.DocumentNode.SelectNodes("//*[@class='core']").ToArray();

                foreach (HtmlNode Laptop in Laptops)
                {
                    Console.WriteLine(Laptop.InnerText);
                }
            }

            while(Console.ReadKey().Key == ConsoleKey.N)
            {
                NextPage();
            }

            Console.ReadLine();

        }
    }
}
