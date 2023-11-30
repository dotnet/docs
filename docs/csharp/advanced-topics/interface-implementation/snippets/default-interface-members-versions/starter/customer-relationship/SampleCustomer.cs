namespace customer_relationship;

public class SampleCustomer : ICustomer
{
    public SampleCustomer(string name, DateTime dateJoined) =>
        (Name, DateJoined) = (name, dateJoined);

    private List<IOrder> allOrders = new List<IOrder>();

    public IEnumerable<IOrder> PreviousOrders => allOrders;

    public DateTime DateJoined { get; }

    public DateTime? LastOrder { get; private set; }

    public string Name { get; }

    private Dictionary<DateTime, string> reminders = new Dictionary<DateTime, string>();
    public IDictionary<DateTime, string> Reminders => reminders;

    public void AddOrder(IOrder order)
    {
        if (order.Purchased > (LastOrder ?? DateTime.MinValue))
            LastOrder = order.Purchased;
        allOrders.Add(order);
    }
}
