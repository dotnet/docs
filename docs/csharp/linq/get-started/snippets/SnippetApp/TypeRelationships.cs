namespace Linq.GetStarted;

public class TypeRelationships
{
    class Customer
    {
        public string City { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone {get; set;}
    }
    static List<Customer> customers = new ();

    public static void ExplicitType()
    {
        //<ExplicitType>
        IEnumerable<Customer> customerQuery = from cust in customers
                                              where cust.City == "London"
                                              select cust;

        foreach (Customer customer in customerQuery)
        {
            Console.WriteLine($"{customer.LastName}, {customer.FirstName}");
        }
        //</ExplicitType>
    }

    public static void ImplicitType()
    {
        //<ImplicitType>
        var customerQuery2 = from cust in customers
                             where cust.City == "London"
                             select cust;

        foreach(var customer in customerQuery2)
        {
            Console.WriteLine($"{customer.LastName}, {customer.FirstName}");
        }
        //</ImplicitType>
    }
}
