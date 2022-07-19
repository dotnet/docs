namespace patterns;

// <OrderRecord>
public record Order(int Items, decimal Cost);
// </OrderRecord>

class OrderProcessor
{
    // <PropertyPattern>
    public decimal CalculateDiscount(Order order) =>
        order switch
        {
            { Items: > 10, Cost: > 1000.00m } => 0.10m,
            { Items: > 5, Cost: > 500.00m } => 0.05m,
            { Cost: > 250.00m } => 0.02m,
            null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
            var someObject => 0m,
        };
    // </PropertyPattern>
}

class OrderProcessing
{
    // <DeconstructPattern>
    public decimal CalculateDiscount(Order order) =>
        order switch
        {
            ( > 10,  > 1000.00m) => 0.10m,
            ( > 5, > 50.00m) => 0.05m,
            { Cost: > 250.00m } => 0.02m,
            null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
            var someObject => 0m,
        };
    // </DeconstructPattern>
}

class ListPattern
{
    // <ListPattern>
    public void MatchElements(int[] array)
    {
        if (array is [0,1])
        {
            Console.WriteLine("Binary Digits");
        }
        else if (array is [1,1,2,3,5,8, ..])
        {
            Console.WriteLine("array looks like a Fibonacci sequence");
        }
        else
        {
            Console.WriteLine("Array shape not recognized");
        }
    }
    // </ListPattern>
}
