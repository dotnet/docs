using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// <Snippet1>
using System.Data.Linq;
using System.Data.Linq.Mapping;
// </Snippet1>

namespace cs_walkthru1
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet4>
            // Use a connection string.
            DataContext db = new DataContext
                (@"c:\linqtest5\northwnd.mdf");

            // Get a typed table to run queries.
            Table<Customer> Customers = db.GetTable<Customer>();
            // </Snippet4>


            

        }
    }
    // <Snippet2>
    [Table(Name = "Customers")]
    public class Customer
    {
    }
    // </Snippet2>

    public class snippet3
    {
     
// <Snippet3>
private string _CustomerID;
[Column(IsPrimaryKey=true, Storage="_CustomerID")]
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
[Column(Storage="_City")]
public string City
{
    get
    {
        return this._City;
    }
    set
    {
        this._City=value;
    }
}
// </Snippet3>
    }

}

