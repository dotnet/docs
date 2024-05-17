namespace customer_relationship;

public interface ICustomer
{
    IEnumerable<IOrder> PreviousOrders { get; }

    DateTime DateJoined { get; }
    DateTime? LastOrder { get; }
    string Name { get; }
    IDictionary<DateTime, string> Reminders { get; }

    /*
    // <SnippetLoyaltyDiscountVersionOne>
    // Version 1:
    public decimal ComputeLoyaltyDiscount()
    {
        DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
        {
            return 0.10m;
        }
        return 0;
    }
    // </SnippetLoyaltyDiscountVersionOne>
    */

    /*
    // <SnippetLoyaltyDiscountVersionTwo>
    // Version 2:
    public static void SetLoyaltyThresholds(
        TimeSpan ago,
        int minimumOrders = 10,
        decimal percentageDiscount = 0.10m)
    {
        length = ago;
        orderCount = minimumOrders;
        discountPercent = percentageDiscount;
    }
    private static TimeSpan length = new TimeSpan(365 * 2, 0,0,0); // two years
    private static int orderCount = 10;
    private static decimal discountPercent = 0.10m;

    public decimal ComputeLoyaltyDiscount()
    {
        DateTime start = DateTime.Now - length;

        if ((DateJoined < start) && (PreviousOrders.Count() > orderCount))
        {
            return discountPercent;
        }
        return 0;
    }
    // </SnippetLoyaltyDiscountVersionTwo>
    */

    // Version 3:
    public static void SetLoyaltyThresholds(TimeSpan ago, int minimumOrders, decimal percentageDiscount)
    {
        length = ago;
        orderCount = minimumOrders;
        discountPercent = percentageDiscount;
    }
    private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0); // two years
    private static int orderCount = 10;
    private static decimal discountPercent = 0.10m;

    // <SnippetFinalVersion>
    public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);
    protected static decimal DefaultLoyaltyDiscount(ICustomer c)
    {
        DateTime start = DateTime.Now - length;

        if ((c.DateJoined < start) && (c.PreviousOrders.Count() > orderCount))
        {
            return discountPercent;
        }
        return 0;
    }
    // </SnippetFinalVersion>
}
