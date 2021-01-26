using System;

namespace SimpleMenuEx2
{
    class Program
    {

        static bool running = true;
        static void Main(string[] args)
        {
            while (running)
            {
                string choice = MainMenuChoice();

                Console.WriteLine("");

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Avslutar programmet...\n");
                        running = false;
                        break;
                    case "1":
                        CinemaTicketMenu();
                        break;
                    case "2":
                        Repeat10Times();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val! Försök igen!\n");
                        break;
                }
                
            }

            Console.WriteLine("Hej då!\n");
            
        }

        static string MainMenuChoice()
        {
            Console.WriteLine($"Huvudmeny");
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("0 - Avsluta programmet");
                Console.WriteLine("1 - Köp biobiljetter");
                Console.WriteLine("2 - Repetera 10 gånger");
                

                Console.Write("\nDitt val: ");
                
                return Console.ReadLine();
        }

        static void CinemaTicketMenu()
        {
            Console.WriteLine("Hur många personer ska gå på bio?");
            Console.Write("Antal personer: ");

            var number = Convert.ToInt32(Console.ReadLine());
            
            if (number > 0)
            {
                int totalPrice = 0;
                for (var i = 0; i < number; i++)
                {
                    Console.Write($"Ålder för person {i + 1} i hela år : ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    if (age < 20)
                    {
                        if (age >= 5)
                        {
                            Console.WriteLine("Ungdomspris: 80 kr.");
                            totalPrice += 80;
                        }
                        else 
                        {
                            Console.WriteLine($"Barn uder 5 år går gratis.");
                        }
                    }
                    else if (age > 64)
                    {
                        if (age < 100)
                        {
                            Console.WriteLine("Pensionärpris: 90 kr.");
                            totalPrice += 90;
                        }
                        else
                        {
                            Console.WriteLine("Hudraåringar går gratis.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Standardpris: 120 kr.");
                        totalPrice += 120;
                    }
                }
                Console.WriteLine($"Totalpriset för biobiljetterna blir {totalPrice} kr.\n");
            }
            else
            {
                Console.WriteLine($"Antalet personer kan inte vara mindre än 1!");
            }
        }

        static void Repeat10Times()
        {
            Console.WriteLine("Mata in frasen som ska uprepas");
            Console.Write("Frasen: ");
            var phrase = Console.ReadLine();
            for (var i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}. {phrase}" + (i < 9 ? ", " : "!\n"));                
            }
            Console.WriteLine("\n");
            
        }
    }
}
