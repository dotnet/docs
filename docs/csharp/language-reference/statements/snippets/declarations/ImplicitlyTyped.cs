
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
        List<Customer> customers = new List<Customer>();
        //<VarExample>
        // Example #1: var is optional when
        // the select clause specifies a string
        string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
        var wordQuery = from word in words
                        where word[0] == 'g'
                        select word;

        // Because each element in the sequence is a string,
        // not an anonymous type, var is optional here also.
        foreach (string s in wordQuery)
        {
            Console.WriteLine(s);
        }

        // Example #2: var is required because
        // the select clause specifies an anonymous type
        var custQuery = from cust in customers
                        where cust.City == "Phoenix"
                        select new { cust.Name, cust.Phone };

        // var must be used because each item
        // in the sequence is an anonymous type
        foreach (var item in custQuery)
        {
            Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
        }
        //</VarExample>
    }
}
