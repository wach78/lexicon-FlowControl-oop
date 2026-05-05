using System;
using System.Collections.Generic;
using System.Text;

using Ovn2FlowControl.Enums;

namespace Ovn2FlowControl.Records
{
    sealed record TicketPrice(
             TicketPriceType Type,
             string PriceType,
             int Price
         );

}
