using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_walk2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Use a connection string.
            DataContext db = new DataContext
                (@"c:\linqtest5\northwnd.mdf");

            // Get a typed table to run queries.
            Table<Customer> Customers = db.GetTable<Customer>();

            // <Snippet3>
            // Query for customers who have placed orders.
            var custQuery =
                from cust in Customers
                where cust.Orders.Any()
                select cust;

            foreach (var custObj in custQuery)
            {
                Console.WriteLine("ID={0}, Qty={1}", custObj.CustomerID,
                    custObj.Orders.Count);
            }
            // </Snippet3>
        }

        void method5()
        {
            // <Snippet5>
            // Use a connection string.
            Northwind db = new Northwind(@"C:\linqtest5\northwnd.mdf");

            // Query for customers from Seattle.
            var custQuery =
                from cust in db.Customers
                where cust.City == "Seattle"
                select cust;

            foreach (var custObj in custQuery)
            {
                Console.WriteLine($"ID={custObj.CustomerID}");
            }
            // Freeze the console window.
            Console.ReadLine();
            // </Snippet5>
        }
    }

    // <Snippet4>
    public class Northwind : DataContext
    {
        // Table<T> abstracts database details per table/data type.
        public Table<Customer> Customers;
        public Table<Order> Orders;

        public Northwind(string connection) : base(connection) { }
    }
    // </Snippet4>

    [Table(Name = "Customers")]
    public class Customer
    {
        // <Snippet2>
        private EntitySet<Order> _Orders;
        public Customer()
        {
            this._Orders = new EntitySet<Order>();
        }

        [Association(Storage = "_Orders", OtherKey = "CustomerID")]
        public EntitySet<Order> Orders
        {
            get { return this._Orders; }
            set { this._Orders.Assign(value); }
        }
        // </Snippet2>

        private string _CustomerID;
        [Column(IsPrimaryKey = true, Storage = "_CustomerID")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
            }
        }

        private string _City;
        [Column(Storage = "_City")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }
    }

    // <Snippet1>
    [Table(Name = "Orders")]
    public class Order
    {
        private int _OrderID = 0;
        private string _CustomerID;
        private EntityRef<Customer> _Customer;
        public Order() { this._Customer = new EntityRef<Customer>(); }

        [Column(Storage = "_OrderID", DbType = "Int NOT NULL IDENTITY",
        IsPrimaryKey = true, IsDbGenerated = true)]
        public int OrderID
        {
            get { return this._OrderID; }
            // No need to specify a setter because IsDBGenerated is
            // true.
        }

        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
        public string CustomerID
        {
            get { return this._CustomerID; }
            set { this._CustomerID = value; }
        }

        [Association(Storage = "_Customer", ThisKey = "CustomerID")]
        public Customer Customer
        {
            get { return this._Customer.Entity; }
            set { this._Customer.Entity = value; }
        }
    }
    // </Snippet1>
}
