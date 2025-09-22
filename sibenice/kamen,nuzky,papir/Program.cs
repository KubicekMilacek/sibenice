using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vítejte ve hře Kámen, Nůžky, Papír!");
        Console.WriteLine("Zadejte svůj tah (kámen, nůžky, papír):");

        string[] moznosti = { "kamen", "nuzky", "papir" };
        Random random = new Random();

        while (true)
        {
            Console.Write("Váš tah: ");
            string uzivatelskyTah = Console.ReadLine()?.ToLower();

            if (uzivatelskyTah == "konec")
            {
                Console.WriteLine("Děkujeme za hru!");
                break;
            }

            if (!Array.Exists(moznosti, moznost => moznost == uzivatelskyTah))
            {
                Console.WriteLine("Neplatný tah. Zadejte 'kámen', 'nůžky', 'papír' nebo 'konec' pro ukončení.");
                continue;
            }

            string pocitacovyTah = moznosti[random.Next(moznosti.Length)];
            Console.WriteLine($"Počítač zvolil: {pocitacovyTah}");

            if (uzivatelskyTah == pocitacovyTah)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((uzivatelskyTah == "kámen" && pocitacovyTah == "nůžky") ||
                     (uzivatelskyTah == "nůžky" && pocitacovyTah == "papír") ||
                     (uzivatelskyTah == "papír" && pocitacovyTah == "kámen"))
            {
                Console.WriteLine("Vyhrál(a) jste!");
            }
            else
            {
                Console.WriteLine("Prohrál(a) jste!");
            }

            Console.WriteLine();
        }
    }
}