
using Ovn2_FlowControl.Enums.Services;
using Ovn2FlowControl.Enums;
using System;

namespace Ovn2FlowControl
{
    internal class Program
    {

        private const int RepeatCount = 10;
        private const int FirstRepeatNumber = 1;

        static void Main(string[] args)
        {
            bool isRunning = true;
            int? choice;

            while (isRunning)
            {
                Console.Write(
                    $"""
                    Välkommen till huvudmenyn.
                    Skriv en siffra för att välja funktion.
                    {(int)MenuChoice.Quit} = Avsluta
                    {(int)MenuChoice.TicketPrice} = Ungdom eller pensionär
                    {(int)MenuChoice.GroupTicketPrice} = Pris för sällskap
                    {(int)MenuChoice.RepeatText} = Upprepa tio gånger
                    {(int)MenuChoice.PrintWordInterval} = Det tredje ordet
                    Ditt val:
                    """
                 );

                choice = InputInt("Ogiltigt val. Ange ett nummer.");

                if (choice is null)
                {
                    continue;
                }

                MenuChoice numericChoice = (MenuChoice)choice;

                switch (numericChoice)
                {
                    case MenuChoice.Quit:
                        isRunning = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    case MenuChoice.TicketPrice:
                        UngdomEllerPensionar();
                        break;

                    case MenuChoice.GroupTicketPrice:
                        PrisForSallskap();
                        break;

                    case MenuChoice.RepeatText:
                        HandleRepeatText();
                        break;

                    case MenuChoice.PrintWordInterval:
                        DetTredjeOrdet();
                        break;

                    default:
                        Console.WriteLine("Felaktig input");
                        break;
                }

                Console.WriteLine();
            }
        }

        static int? InputInt(string errorMessage)
        {
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine();
                return null;
            }

            return choice;
        }

        static bool IsValidText(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        static void HandleRepeatText()
        {
            Console.Write("Skriv din text här: ");
            string? input = Console.ReadLine();

            if (!IsValidText(input))
            {
                Console.WriteLine("Text can not be empty.");
                Console.WriteLine();
                return;
            }


            var textRepeater = new TextRepeater(FirstRepeatNumber, RepeatCount);

            textRepeater.RepeatText(input);
        }

        static void UngdomEllerPensionar()
        {
            Console.Write("Ange ålder: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int alder))    // Jämför med int.Parse(input) --> "hej" --> Exception
            {
                Console.WriteLine("Ogiltig ålder.");
                return;
            }

            if (alder < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr");
            }
            else if (alder > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr");
            }
            else
            {
                Console.WriteLine("Standardpris: 120kr");
            }
        }

        static void PrisForSallskap()
        {
            Console.Write("Hur många personer är ni? ");
            string? antalInput = Console.ReadLine();

            if (!int.TryParse(antalInput, out int antal) || antal <= 0)
            {
                Console.WriteLine("Ogiltigt antal personer.");
                return;
            }

            int total = 0;

            for (int i = 1; i <= antal; i++)
            {
                Console.Write($"Ange ålder för person {i}: ");
                string? alderInput = Console.ReadLine();

                if (!int.TryParse(alderInput, out int alder) || alder < 0)
                {
                    Console.WriteLine("Ogiltig ålder.");
                    return;
                }

                if (alder < 5 || alder > 100)
                {
                    Console.WriteLine($"Person {i}: Gratis");
                }
                else if (alder < 20)
                {
                    total += 80;
                }
                else if (alder > 64)
                {
                    total += 90;
                }
                else
                {
                    total += 120;
                }
            }

            Console.WriteLine($"Antal personer: {antal}");
            Console.WriteLine($"Totalkostnad: {total} kr");
        }


        static void DetTredjeOrdet()
        {
            Console.Write("Skriv en mening med minst 3 ord: ");
            string? mening = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mening))
            {
                Console.WriteLine("Du måste skriva en mening.");
                return;
            }

            string[] ord = mening.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (ord.Length < 3)
            {
                Console.WriteLine("Mening måste innehålla minst 3 ord.");
                return;
            }

            Console.WriteLine($"Det tredje ordet är: {ord[2]}");
        }
    }
}

