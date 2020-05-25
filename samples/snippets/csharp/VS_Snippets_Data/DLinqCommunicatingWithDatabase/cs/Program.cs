using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace cs_test20730build
{
    class Program
    {
        static void Main(string[] args)
        {

          //  Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            // <Snippet1>
// DataContext takes a connection string.
DataContext db = new DataContext(@"c:\Northwind.mdf");

// Get a typed table to run queries.
Table<Customer> Customers = db.GetTable<Customer>();

// Query for customers from London.
var query =
    from cust in Customers
    where cust.City == "London"
    select cust;

foreach (var cust in query)
    Console.WriteLine("id = {0}, City = {1}", cust.CustomerID, cust.City);
            // </Snippet1>

            // <Snippet3>
            db.ExecuteCommand("UPDATE Products SET UnitPrice = UnitPrice + 1.00");
            // </Snippet3>

            // <Snippet4>
            string connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\northwind.mdf;
                Integrated Security=True; Connect Timeout=30; User Instance=True";
            SqlConnection nwindConn = new SqlConnection(connString);
            nwindConn.Open();

            Northwnd interop_db = new Northwnd(nwindConn);

            SqlTransaction nwindTxn = nwindConn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Products SET QuantityPerUnit = 'single item' WHERE ProductID = 3");
                cmd.Connection = nwindConn;
                cmd.Transaction = nwindTxn;
                cmd.ExecuteNonQuery();

                interop_db.Transaction = nwindTxn;

                Product prod1 = interop_db.Products
                    .First(p => p.ProductID == 4);
                Product prod2 = interop_db.Products
                    .First(p => p.ProductID == 5);
                prod1.UnitsInStock -= 3;
                prod2.UnitsInStock -= 5;

                interop_db.SubmitChanges();

                nwindTxn.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error submitting changes... all changes rolled back.");
            }

            nwindConn.Close();
            // </Snippet4>

            Console.ReadLine();
        } //end of Main

        // <Snippet2>
        public partial class Northwind : DataContext
        {
            public Table<Customer> Customers;
            public Table<Order> Orders;
            public Northwind(string connection) : base(connection) { }
        }
        // </Snippet2>

       void method()
        {
            // <Snippet5>
            Northwnd db = new Northwnd(@"c:\Northwnd.mdf");
            var query =
                from cust in db.Customers
                where cust.City == "London"
                select cust;
            foreach (var cust in query)
                Console.WriteLine("id = {0}, City = {1}", cust.CustomerID,
                    cust.City);
            // </Snippet5>
        }
    }
}
