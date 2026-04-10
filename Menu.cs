using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                if (!parseTest || answer > 7 || answer < 1)
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
                            SecondQuery(context);
                            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            ThirdQuery(context);
                            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            FourthQuery(context);
                            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            FithtQuery(context);
                            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
                            Console.ReadKey();
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

            foreach (var product in result)
            {
                Console.WriteLine($"Produkt:{product.Name} Pris:{product.Price}");
            }


        }

        //Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        //public static void SecondQuery(ShopContext context)
        //{
        //    var result = context.Products
        //        .Where(p => p.StockQuantity < 10)
        //        .Select(s => s.Supplier.Name)
        //        .Distinct().ToList();//Distint gör så att ingen leverantör läggs in dubbelt.

        //    foreach (var supplier in result)
        //    {

        //        Console.WriteLine($"Leverantör: {supplier}");

        //    }
        //}

        //Lade till så man ser produkterna också
        public static void SecondQuery(ShopContext context)
        {
            var result = context.Products
                .Where(p => p.StockQuantity < 10).GroupBy(p => p.Supplier.Name).ToList();

            foreach (var supplier in result)
            {

                Console.WriteLine($"Leverantör: {supplier.Key}");
                Console.WriteLine("Produkter:\n");
                foreach (var p in supplier)
                {
                    Console.WriteLine("-" + p.Name);
                }
                Console.WriteLine("");


            }


        }


        //3.Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        public static void ThirdQuery(ShopContext context)
        {
            var result = context.Orders.Where(o => o.OrderDate > (DateTime.Now.AddMonths(-1)))
                .Select(o => o.TotalAmount)
                .ToList();
            var grandTotal = 0;
            foreach (var ordertotal in result)
            {
                grandTotal = grandTotal + ordertotal;
            }//finns tydligen en "sum" funktion som gör att man slipper loopa...
            Console.WriteLine($"Total försäljning senaste månaden:{grandTotal}Kr");
        }

        //4.Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        public static void FourthQuery(ShopContext context)
        {

            var products = context.OrderDetails.GroupBy(group => group.Product.Name)
            .Select(finalresult => new
            {
                produkt = finalresult.Key,
                antalSålda = finalresult.Sum(summa => summa.Quantity)// måste göra Select för att skapa antalSålda (summa) som vi sedan kan sortera på

            }).OrderByDescending(summa => summa.antalSålda).Take(3).ToList();//Take väljer ut specifikt antal


            Console.WriteLine("Populäraste produkter:\n");
            foreach (var x in products)
            {
              
                Console.WriteLine($"Produkt:{x.produkt}");
                Console.WriteLine($"Sålt antal: {x.antalSålda}");
              

            }

        }

        //5.Lista alla kategorier och antalet produkter i varje kategori
        public static void FithtQuery(ShopContext context)
        {
            var result = context.Products.GroupBy(p => p.Category).Select(x => new {

                //måste plocka ut värderna från group "GroupBy ger dig "högar" av data – Select gör dem mätbara."
                Kategori = x.Key.Name,
                AntalProdukter = x.Count()

            }).ToList();

            foreach(var produkt in result)
            {
                Console.WriteLine($"{produkt.Kategori} \nAntal produkter:{produkt.AntalProdukter}");
                Console.WriteLine();
            }
            
        }

        public static void SixthQueary()
        {

        }
    }
}
