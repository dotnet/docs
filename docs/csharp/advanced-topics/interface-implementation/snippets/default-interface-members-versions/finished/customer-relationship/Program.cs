using customer_relationship;
// <SnippetTestDefaultImplementation>
SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
{
    Reminders =
    {
        { new DateTime(2010, 08, 12), "childs's birthday" },
        { new DateTime(2012, 11, 15), "anniversary" }
    }
};

SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
c.AddOrder(o);

o = new SampleOrder(new DateTime(2013, 7, 4), 25m);
c.AddOrder(o);

// <SnippetHighlightCast>
// Check the discount:
ICustomer theCustomer = c;
Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
// </SnippetHighlightCast>
// </SnippetTestDefaultImplementation>

// Add more orders to get the discount:
DateTime recurring = new DateTime(2013, 3, 15);
for(int i = 0; i < 15; i++)
{
    o = new SampleOrder(recurring, 19.23m * i);
    c.AddOrder(o);

    recurring.AddMonths(2);
}

Console.WriteLine($"Data about {c.Name}");
Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
Console.WriteLine("Reminders:");
foreach(var item in c.Reminders)
{
    Console.WriteLine($"\t{item.Value} on {item.Key}");
}
foreach (IOrder order in c.PreviousOrders)
    Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");

Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

// <SnippetSetLoyaltyThresholds>
ICustomer.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
// </SnippetSetLoyaltyThresholds>
