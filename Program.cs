
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
                    {(int)MenuChoice.TicketPrice} = Ungdom eller pensionär
                    {(int)MenuChoice.GroupTicketPrice} = Pris för sällskap
                    {(int)MenuChoice.RepeatText} = Upprepa tio gånger
                    {(int)MenuChoice.PrintWordInterval} = Det tredje ordet
                    {(int)MenuChoice.Quit} = Avsluta
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
                        HandleTicketPrice();
                        break;

                    case MenuChoice.GroupTicketPrice:
                        HandleGroupTicketPrice();
                        break;

                    case MenuChoice.RepeatText:
                        HandleRepeatText();
                        break;

                    case MenuChoice.PrintWordInterval:
                        HandleThridWord();
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

            string repeatedText = textRepeater.RepeatText(input);

            Console.WriteLine(repeatedText);
        }

        static void HandleThridWord()
        {
            Console.Write("Skriv in minst tre ord här: ");
            string? text = Console.ReadLine();

            try
            {
                var thirdWordExtractor = new ThirdWordExtractor(text);

                Console.WriteLine($"Det tredje ordet är: {thirdWordExtractor}");
            }
            catch (InvalidOperationException invalidOperationException)
            {
                Console.WriteLine(invalidOperationException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }


        }

        static void HandleTicketPrice()
        {
            Console.Write("Skriv in ålder: ");

            int? age = InputInt("Ange en giltig ålder.");

            try
            {
                TicketPriceCalculator calculator = new();

                var ticket = calculator.Calculate(age);

                Console.WriteLine(ticket);
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine(argumentOutOfRangeException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }


        }

        static void HandleGroupTicketPrice()
        {
            Console.Write("Skriv antalet bio besökare: ");

            int? visitors = InputInt("Ange ett giltigt antal biobesökare.");

            if (visitors is null || visitors <= 0)
            {
                Console.WriteLine("Ange ett giltigt antal biobesökare");
                return;
            }

            int? age;
            int[] ages = new int[visitors.Value];

            for (int i = 0; i < visitors; i++)
            {
                Console.Write("Skriv in ålder: ");
                age = InputInt("Ange en giltig ålder.");

                if (age is null || age < 0)
                {
                    Console.WriteLine("Åldern är ogiltig");
                    return;
                }

                ages[i] = age.Value;

            }


            TicketPriceCalculator calculator = new();

            int totalPrice = calculator.CalculateTotalPrice(ages);

            Console.WriteLine($"Antal besökare: {visitors}");
            Console.WriteLine($"Total pris: {totalPrice}");

        }
    }
}

