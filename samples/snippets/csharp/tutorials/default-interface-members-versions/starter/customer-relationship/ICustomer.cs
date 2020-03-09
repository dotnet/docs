using System;
using System.Collections.Generic;

namespace customer_relationship
{
    // <SnippetICustomerVersion1>
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }
    }
    // </SnippetICustomerVersion1>
}
