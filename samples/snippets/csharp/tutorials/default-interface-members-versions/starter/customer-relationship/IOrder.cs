using System;

namespace customer_relationship
{
    // <SnippetIOrderVersion1>
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
    // </SnippetIOrderVersion1>
}
