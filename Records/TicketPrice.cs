using System;
using System.Collections.Generic;
using System.Text;

using Ovn2_FlowControl.Enums;

namespace Ovn2_FlowControl.Records
{
    sealed record TicketPrice(
             TicketPriceType Type,
             string PriceType,
             int Price
         );

}
