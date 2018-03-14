using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace cs_walk1part2
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

            // <Snippet5>
            // Attach the log to show generated SQL.
            db.Log = Console.Out;

            // Query for customers in London.
            IQueryable<Customer> custQuery =
                from cust in Customers
                where cust.City == "London"
                select cust;
            // </Snippet5>

            // <Snippet6>
            foreach (Customer cust in custQuery)
            {
                Console.WriteLine("ID={0}, City={1}", cust.CustomerID,
                    cust.City);
            }

            // Prevent console window from closing.
            Console.ReadLine();
            // </Snippet6>

        }
    }

    [Table(Name = "Customers")]
    public class Customer
    {

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

}
