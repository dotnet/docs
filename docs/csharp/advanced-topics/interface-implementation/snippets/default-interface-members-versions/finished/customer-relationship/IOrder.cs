namespace customer_relationship;

public interface IOrder
{
    DateTime Purchased { get; }
    decimal Cost { get; }
}
