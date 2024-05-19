
namespace ImplicitTypes;

class Customer
{
    public string City { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}

public static class VarExample
{
    public static void ImplicitlyTyped()
    {
        // <ImplicitlyTyped>
        var greeting = "Hello";
        Console.WriteLine(greeting.GetType());  // output: System.String

        var a = 32;
        Console.WriteLine(a.GetType());  // output: System.Int32

        var xs = new List<double>();
        Console.WriteLine(xs.GetType());  // output: System.Collections.Generic.List`1[System.Double]
        // </ImplicitlyTyped>

        List<Customer> customers = new List<Customer>();
        //<VarExample>
        var fromPhoenix = from cust in customers
                          where cust.City == "Phoenix"
                          select new { cust.Name, cust.Phone };

        foreach (var customer in fromPhoenix)
        {
            Console.WriteLine($"Name={customer.Name}, Phone={customer.Phone}");
        }
        //</VarExample>
    }
}
