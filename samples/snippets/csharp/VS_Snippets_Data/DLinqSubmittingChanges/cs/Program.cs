using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Transactions;

namespace cs_submittingchanges
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // Make changes here.
            try
            {
                db.SubmitChanges();
            }
            catch (ChangeConflictException e)
            {
                Console.WriteLine(e.Message);
                // Make some adjustments.
                // ...
                // Try again.
                db.SubmitChanges();
            }
            // </Snippet1>
        }

        void method2()
        {
            // <Snippet2>
            // using System.Reflection;
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");

            Customer newCust = new Customer();
            newCust.City = "Auburn";
            newCust.CustomerID = "AUBUR";
            newCust.CompanyName = "AubCo";
            db.Customers.InsertOnSubmit(newCust);

            try
            {
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException e)
            {
                Console.WriteLine("Optimistic concurrency error.");
                Console.WriteLine(e.Message);
                Console.ReadLine();
                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    MetaTable metatable = db.Mapping.GetTable(occ.Object.GetType());
                    Customer entityInConflict = (Customer)occ.Object;
                    Console.WriteLine($"Table name: {metatable.TableName}");
                    Console.Write("Customer ID: ");
                    Console.WriteLine(entityInConflict.CustomerID);
                    foreach (MemberChangeConflict mcc in occ.MemberConflicts)
                    {
                        object currVal = mcc.CurrentValue;
                        object origVal = mcc.OriginalValue;
                        object databaseVal = mcc.DatabaseValue;
                        MemberInfo mi = mcc.Member;
                        Console.WriteLine($"Member: {mi.Name}");
                        Console.WriteLine($"current value: {currVal}");
                        Console.WriteLine($"original value: {origVal}");
                        Console.WriteLine($"database value: {databaseVal}");
                    }
                }
            }
            catch (Exception ee)
            {
                // Catch other exceptions.
                Console.WriteLine(ee.Message);
            }
            finally
            {
                Console.WriteLine("TryCatch block has finished.");
            }
            // </Snippet2>
        }

        void method3()
        {
            // <Snippet3>
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Product prod1 = db.Products.First(p => p.ProductID == 4);
                    Product prod2 = db.Products.First(p => p.ProductID == 5);
                    prod1.UnitsInStock -= 3;
                    prod2.UnitsInStock -= 5;
                    db.SubmitChanges();
		    ts.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            // </Snippet3>
        }

        // <Snippet6>
        public void CreateDatabase()
        {
            MyDVDs db = new MyDVDs("c:\\mydvds.mdf");
            db.CreateDatabase();
        }
       // </Snippet6>

        // <Snippet7>
        public void CreateDatabase2()
        {
            MyDVDs db = new MyDVDs(@"c:\mydvds.mdf");
            if (db.DatabaseExists())
            {
                Console.WriteLine("Deleting old database...");
                db.DeleteDatabase();
            }
            db.CreateDatabase();
        }
        // </Snippet7>
    }

    // <Snippet4>
    // Code-generating tool defines a partial class, including
    // two partial methods.
    partial class ExampleClass
    {
        partial void onFindingMaxOutput();
        partial void onFindingMinOutput();
    }

    // Developer implements one of the partial methods. Compiler
    // discards the signature of the other method.
    partial class ExampleClass
    {
        partial void onFindingMaxOutput()
        {
            Console.WriteLine("Maximum has been found.");
        }
    }
    // </Snippet4>

    // <Snippet5>
    public class MyDVDs : DataContext
    {
        public Table<DVD> DVDs;
        public MyDVDs(string connection) : base(connection) { }
    }

    [Table(Name = "DVDTable")]
    public class DVD
    {
        [Column(IsPrimaryKey = true)]
        public string Title;
        [Column]
        public string Rating;
    }
// </Snippet5>
}
