using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;


namespace cs_kathytest081707c
{
    

    class Program
    {
        static void Main(string[] args)
        {

            // <Snippet1>
            using (Northwnd db = new Northwnd(@"c:\northwnd.mdf"))
            {
                // Get original Customer from deserialization.
                var q1 = db.Orders.First();
                string serializedQ = SerializeHelper.Serialize(q1);
                var q2 = SerializeHelper.Deserialize(serializedQ, q1);

                // Track this object for an update (not insert).
                db.Orders.Attach(q2, false);

                // Replay the changes.
                q2.ShipRegion = "King";
                q2.ShipAddress = "1 Microsoft Way";

                // DataContext knows how to update the order.
                db.SubmitChanges();
                               
            }
            // </Snippet1>
        }

        void method3()
        {
            // <Snippet3>
            Customer CustA_File = new Customer();
            Customer CustB_File = new Customer();
            string xmlFileA = "";
            string xmlFileB = "";

            // Get the serialized objects.
            Customer A = SerializeHelper.Deserialize<Customer>(xmlFileA, CustA_File);
            Customer B = SerializeHelper.Deserialize<Customer>(xmlFileB, CustB_File);
            List<Order> AOrders = A.Orders.ToList();

            using (Northwnd db = new Northwnd(@"c:\northwnd.mdf"))

            {
                //Attach all the orders belonging to Customer A all at once.
                db.Orders.AttachAll(AOrders, false);

                // Update the orders belonging to Customer A to show them
                // as owned by Customer B.
                foreach (Order o in AOrders)
                {
                    o.CustomerID = B.CustomerID;
                }

                // DataContext can now apply the change of ownership to
                // the database.
                db.SubmitChanges();
            }
            // </Snippet3>


        }

        void method4()
        {
            // <Snippet4>
            using (Northwnd db2 = new Northwnd(@"c:\northwnd.mdf"))
            {
                Customer Cust_File = new Customer();
                string xmlFile = "";
                
                // Get the original object from the deserializer.
                Customer c = SerializeHelper.Deserialize<Customer>
                    (xmlFile, Cust_File);

                // Set all the desired properties to the entity to be attached.
                Customer c_updated = new Customer() { CustomerID = c.CustomerID,
                    Phone = "425-123-4567", CompanyName = "Microsoft" };
                db2.Customers.Attach(c_updated, c);
      
                // Perform last minute updates, which will still take effect. 
                c_updated.Phone = "425-765-4321";

                // SubmitChanges()sets the phoneNumber and CompanyName of
                // customer with customerID=Cust. to "425-765-4321" and
                // "Microsoft" respectively.
                db2.SubmitChanges();  
            }
            // </Snippet4>

        }

        // s5 is skipped


        //void method6()
        //{
        //    // s6: skip until it compiles
            
        //    // This tier uses DataLoadOptions to disable deferred loading. Only the
        //    // customer and orders are moved in a single serialization.       

        //    DataLoadOptions shape = new DataLoadOptions();
        //    shape.LoadWith<Customer>(c => c.Orders);
        //    shape.AssociateWith<Customer>
        //        (c => c.Orders.Where(o => o.OrderDate.Year = 2007));

        //    using (Northwnd db1 = new Northwnd(@"c:\northwnd.mdf"))
        //    {
        //        Northwnd db = new Northwnd("");

        //        Customer cust = db1.Customers.First(x => x.CustomerID == "ALKFI");
        //        Order ordA = cust.Orders.First();
        //        Order ordB = cust.Orders.First(x => x.OrderID > ordA.OrderID);
        //        /* Customer cust and its Orders ord1 and ord2 are serialized here
        //        and transported over the wire or to another tier.*/

        //        db1LoadOptions = shape;
        //        db.DeferredLoadingEnabled = false;

        //        Customer cust = db1.Customers.First(x => x.CustomerID == "ALKFI");
        //        SerializeHelper.Serialize(cust, xmlFile);

        //    }

        //    // The following is a different tier using a different DataContext.
        //    using (Northwnd db2 = new Northwnd(@"c:\northwnd.mdf"))
        //    {
        //        // cust, ord1 and ord2 are deserialized here.
        //        Customer cust = (Customer)
        //            SerializeHelper.Deserialize<Customer>(xmlFile);
        //        Order orderA = cust.Orders.First();
        //        Order orderB = cust.Orders.First(x => x.OrderID > ordA.OrderID);

        //        // Create a new Order to be added to Customer cust.
        //        Order orderC = new Order()
        //        {
        //            OrderID = 12345,
        //            CustomerID =
        //                cust.CustomerID
        //        };

        //        /* Attach the customers and the Orders so that IdentityTracker and
        //        ChangeTracker are aware of these entity objects.*/
        //        db2.Customers.Attach(cust, false);
        //        db2.Orders.AttachAll(cust.Orders.ToList());

        //        /* Perform the modifications on the objects. Specifically,
        //        update customer, update order A, remove order B,
        //        and Add order C.*/
        //        cust.Phone = "2345 5436";
        //        orderA.ShipCity = "redmond";
        //        cust.Orders.DeleteOnSubmit(orderB);
        //        cust.Orders.InsertOnSubmit(orderC);

        //        // Submit all the changes.
        //        db2.SubmitChanges();
        //    }

        //}

        void method7()
        {
            // <Snippet7>
            Customer c = null;
            using (Northwnd db = new Northwnd(""))
            {
                /* Get both the customer c and the customer's order
                into the cache. */
                c = db.Customers.First();
                string sc = c.Orders.First().ShipCity;
            }

            using (Northwnd nw2 = new Northwnd(""))
            {
                // Attach customers and update the address.
                nw2.Customers.Attach(c, false);
                c.Address = "new";
                nw2.Log = Console.Out;

                /* At SubmitChanges, you will see INSERT requests for all
                Customer c’s orders. */
                nw2.SubmitChanges();
            }
            // </Snippet7>

        }

        
    }

    partial class Northwind_Simplified : Northwnd
    {
        Northwind_Simplified nws = new Northwind_Simplified("");
        partial void OnCreated();
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
    static Northwind_Simplified()
	{
	}

    void method2()
    {
        // <Snippet2>
        // Create a DataContext instance for attach
        using (Northwind_Simplified db = new Northwind_Simplified(@"c:\NwSimplified.mdf"))
        {
            /*Create a new entity containing ID of the Shipper. Only the
            ShipperID and Company Name is required for optimistic
            concurrency.*/
            Shipper s = new Shipper()
            {
                ShipperID = 1,
                CompanyName = "United Package"
            };

            /* Track this object for a Delete operation by using
            overloaded Attach with the boolean default (false).*/
            db.Shippers.Attach(s);

            /* Perform the Delete operation AFTER the attach has made the
            datacontext aware of this object.*/
            db.Shippers.DeleteOnSubmit(s);

            /* DataContext now knows how to delete the customer. But
            because there is a foreign key constraint, a SQLException is
            thrown. The Delete operation cannot complete at this time. */
            db.SubmitChanges();
        }
        // </Snippet2>

    }
    
    public Northwind_Simplified(string connection) :
        base(connection, mappingSource)
    {
        OnCreated();
    }
	
	public Northwind_Simplified(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public Northwind_Simplified(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}

    public Northwind_Simplified(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }



    class SerializeHelper
    {
        public static string Serialize(object o)
        {
            DataContractSerializer dcs = new DataContractSerializer(o.GetType());
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            dcs.WriteObject(writer, o);
            writer.Close();
            string ret = sb.ToString();
            return ret;
        }
        public static T Deserialize<T>(string xml, T template)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            StringReader sr = new StringReader(xml);
            XmlReader reader = XmlReader.Create(sr);
            object ret = dcs.ReadObject(reader);
            return (T)ret;
        }
    }
}
