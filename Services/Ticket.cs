using Ovn2FlowControl.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.AccessControl;
using System.Text;

namespace Ovn2_FlowControl.Enums.Services
{
    internal class Ticket
    {
        public Ticket (TicketPriceType tickeType, int price, string description)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price can not be negative.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Text info can not be empty.", nameof(description));
            }

            TickeType = tickeType;
            Price = price;
            Description = description;
        }

        public TicketPriceType TickeType { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Description}: {Price} kr";
        }
    }
}
