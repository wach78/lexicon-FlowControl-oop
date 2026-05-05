using System;
using Ovn2FlowControl.Enums;

namespace Ovn2_FlowControl.Services
{
    internal class TicketPriceCalculator
    {
        // Age limits used when calculating ticket price
        private const int FreeChildMaximumAge = 5;
        private const int YouthMaximumAge = 19;
        private const int SeniorMinimumAge = 65;
        private const int FreeSeniorMinimumAge = 100;

        // Ticket prices in SEK used when calculating cinema admission.
        private const int FreePrice = 0;
        private const int YouthPrice = 80;
        private const int AdultPrice = 120;
        private const int SeniorPrice = 90;

        public Ticket Calculate(int? age)
        {
            if (age is null)
            {
                throw new ArgumentException("Text can not be empty.", nameof(age));
            }

            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age can not be negative.");
            }

            if (age <= FreeChildMaximumAge)
            {
                return CreateTicket(TicketPriceType.FreeChild, FreePrice);
            }

            if (age >= FreeSeniorMinimumAge)
            {
                return CreateTicket(TicketPriceType.FreeSenior, FreePrice);
            }

            if (age <= YouthMaximumAge)
            {
                return CreateTicket(TicketPriceType.Youth, YouthPrice);
            }

            if (age >= SeniorMinimumAge)
            {
                return CreateTicket(TicketPriceType.Senior, SeniorPrice);
            }

            return CreateTicket(TicketPriceType.Adult, AdultPrice);
        }

        private static Ticket CreateTicket(TicketPriceType ticketPriceType, int price)
        {
            return new Ticket(
                ticketPriceType,
                price,
                GetTicketPriceDescription(ticketPriceType)
            );
        }

        private static string GetTicketPriceDescription(TicketPriceType ticketPriceType)
        {
            return ticketPriceType switch
            {
                TicketPriceType.FreeChild => "Gratis barn",
                TicketPriceType.FreeSenior => "Gratis senior",
                TicketPriceType.Youth => "Ungdomspris",
                TicketPriceType.Senior => "Pensionärspris",
                TicketPriceType.Adult => "Standardpris",
                _ => throw new ArgumentOutOfRangeException(nameof(ticketPriceType), ticketPriceType, "Unknown ticket price type."),
            };
        }

        public int CalculateTotalPrice(int[] ages)
        {
            if (ages.Length == 0)
            {
                throw new ArgumentException("Ages can not be empty.", nameof(ages));
            }

            int totalPrice = 0;

            foreach (int age in ages)
            {
                Ticket ticket = Calculate(age);

                totalPrice += ticket.Price;
            }

            return totalPrice;
        }
    }
}
