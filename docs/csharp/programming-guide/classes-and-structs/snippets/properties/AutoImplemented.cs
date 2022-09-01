    namespace AutoImplemented;
    
    //<snippet28>
    // This class is mutable. Its data can be modified from
    // outside the class.
    public class Customer
    {
        // Auto-implemented properties for trivial get and set
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }

        // Constructor
        public Customer(double purchases, string name, int id)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerId = id;
        }

        // Methods
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }

    class Program
    {
        static void Main()
        {
            // Initialize a new object.
            Customer cust1 = new Customer(4987.63, "Northwind", 90108);

            // Modify a property.
            cust1.TotalPurchases += 499.99;
        }
    }
    //</snippet28>
