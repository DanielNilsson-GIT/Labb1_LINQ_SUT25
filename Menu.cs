using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ_SUT25
{
    internal class Menu
    {
        public static void RunProgram()
        {
            bool mainMenu = true;
            var context = new ShopContext();
            do
            {
                Console.Clear();

                Console.WriteLine("Välkommen till LINQ-labben!");
                Console.WriteLine("Vad vill du göra härnäst?\n1.Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)\n" +
                "2.Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter\n" +
                "3.Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden\n" +
                "4.Hitta de 3 mest sålda produkterna baserat på OrderDetail-data\n" +
                "5.Lista alla kategorier och antalet produkter i varje kategori\n" +
                "6.Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr\n" +
                "7.Avsluta");
                string choice = Console.ReadLine();
                var parseTest = int.TryParse(choice, out int answer);
                if (!parseTest||answer>7||answer<1)
                {
                    Console.Clear();
                    Console.WriteLine("Välj ett nummer mellan 1 och 7");
                }
                else
                {
                    switch (answer)
                    {
                        case 1:
                            Console.Clear();
                            FirstQuery(context);
                            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            //metod2
                            break;
                        case 3:
                            Console.Clear();
                            //metod 3
                            break;
                        case 4:
                            Console.Clear();
                            //metod 4
                            break;
                        case 5:
                            Console.Clear();
                            //metod 5
                            break;
                        case 6:
                            Console.Clear();
                            //metod 6
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Tack och hej");
                            mainMenu = false;
                            break;
                    }

                }

            }
            while (mainMenu == true);
            
        }

        //Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)

        public static void FirstQuery(ShopContext context)
        {
            var result = context.Products
                .Where(p => p.Category.Name == "Electronics")
                .OrderByDescending(p => p.Price)
                .ToList();

            foreach(var product in result)
            {
                Console.WriteLine($"Produkt:{product.Name} Pris:{product.Price}");
            }
           
            
        }
    }
}
