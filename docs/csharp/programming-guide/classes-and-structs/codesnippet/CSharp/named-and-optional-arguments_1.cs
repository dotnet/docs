    class NamedExample
    {
        static void Main(string[] args)
        {
            // The method can be called in the normal way, by using positional arguments.
            PrintOrderDetails("Foo", 31, true);

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, isShipped: true, sellerName: "Foo");
            PrintOrderDetails(isShipped: true, sellerName: "Foo", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Foo", 31, isShipped: true);
            PrintOrderDetails("Foo", orderNum: 31, true);
            PrintOrderDetails(sellerName: "Foo", orderNum: 31, true);

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(sellerName: "Foo", true, 31);
            // PrintOrderDetails(31, sellerName: "Foo", true);
            // PrintOrderDetails(31, true, sellerName: "Foo");
        }

        static void PrintOrderDetails(string sellerName, int orderNum, bool isShipped)
        {
            Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Shipped: {isShipped}");
        }
    }
