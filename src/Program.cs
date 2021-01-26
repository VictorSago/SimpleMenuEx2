using System;

namespace SimpleMenuEx2
{
    class Program
    {

        static bool running = true;                     // Variablen som kontrollerar huvudloopen
        static void Main(string[] args)
        {
            while (running)
            {
                string choice = MainMenuChoice();       // Presentera huvudmenyn för användaren

                Console.WriteLine("");                  // För tydlighetens skull

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
                    case "3":
                        SplitString();
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
                Console.WriteLine("1 - Köp biobiljetter");
                Console.WriteLine("2 - Repetera 10 gånger");
                Console.WriteLine("3 - Splittra en sträng");
                Console.WriteLine("0 - Avsluta programmet");

                // Läs in användarens val
                Console.Write("\nDitt val: ");
                return Console.ReadLine();
        }

        static void CinemaTicketMenu()
        {
            // Ta reda på antalet personer som ska gå på bio
            Console.WriteLine("Hur många personer ska gå på bio?");
            Console.Write("Antal personer: ");
            // Konvertera inmatningen till ett heltal
            var number = int.Parse(Console.ReadLine());             // TODO: Input validation for ints
            
            if (number > 0)
            {
                int totalPrice = 0;
                for (var i = 0; i < number; i++)
                {
                    Console.Write($"Ålder för person {i + 1} i hela år : ");
                    var age = int.Parse(Console.ReadLine());        // TODO: Input validation for ints
                    
                    if (age < 20)
                    {
                        // Ungdomspriset gäller personer under 20, om de inte är barn
                        // Barn definieras som "under 5 år gammal"
                        if (age >= 5)
                        {
                            Console.WriteLine("Ungdomspris: 80 kr.");
                            totalPrice += 80;
                        }
                        else 
                        {
                            Console.WriteLine("Barn uder 5 år går gratis.");
                        }
                    }
                    else if (age > 64)
                    {
                        // Pensionärspriset gäller personer över 64, om de inte kvalificerar som 100-åringar
                        // Hundraåringen definieras som "100 år gammal eller äldre"
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
                        // Alla andra som faller i ålersgruppen fom 20 och tom 64 får betala standardpriset
                        Console.WriteLine("Standardpris: 120 kr.");
                        totalPrice += 120;
                    }
                }
                Console.WriteLine($"Totalpriset för biobiljetterna blir {totalPrice} kr.\n");
            }
            else
            // Om antalet besökare är mindre än 1
            {
                Console.WriteLine("Antalet personer kan inte vara mindre än 1!\n");
            }
        }

        static void Repeat10Times()
        // Repetera en sträng 10 gånger
        {
            Console.WriteLine("Mata in frasen som ska uprepas");
            Console.Write("Frasen: ");
            var phrase = Console.ReadLine();            // TODO: Input validation to deal with null values
            
            for (var i = 0; i < 10; i++)
            {
                // Utmatningen ska vara i formen "1. Input, 2. Input, ..., 10. Input"
                // Vi lägger till kommatecknen mellan repetitionerna och ett utropstecken på slutet
                Console.Write($"{i + 1}. {phrase}" + (i < 9 ? ", " : "!\n"));                
            }
            Console.WriteLine("");
            
        }

        static void SplitString()
        {
            Console.WriteLine("Mata in en mening på minst 3 ord lång.");
            Console.Write("Meningen: ");
            var sentence = Console.ReadLine();          // TODO: Input validation to deal with null values
            // Vi vill splittra strängen på mellanslag, men vi vill också bortse från punktuationen,
            // och därför lägger vi till punkt, komma och utropstecken till mellanslaget
            char[] separators = new char[] { ' ', '.', ',', '!' };
            // För att kunna bortse från flera mellanslag i rad samt för att slippa
            // toma strängar som orsakats av splittringen på punkter och kommor
            // behöver vi använda `.RemoveEmptyEntries`
            var subs = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            // Eftersom strängar i C# indexeras från 0 så är `subs[2]` det tredje ordet
            Console.WriteLine($"Det tredje ordet i meningen är: {subs[2]}");
            Console.WriteLine("");
        }
    }
}
