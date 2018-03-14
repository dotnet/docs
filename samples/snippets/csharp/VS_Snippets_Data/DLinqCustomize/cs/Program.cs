using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_maketables
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // <Snippet1>
    [Table(Name = "Customers")]
    public class Customer
    {
        // ...
    }
    // </Snippet1>


// <Snippet2>
[Table(Name="Customers")]
public class customer
{
    [Column(Name="CustomerID")]
    public string CustomerID;
    // ...
}
// </Snippet2>

}



// <Snippet3>
[Table(Name = "Customers")]
public partial class Customer
{
    [Column(IsPrimaryKey = true)]
    public string CustomerID;
    // ...
    private EntitySet<Order> _Orders;
    [Association(Storage = "_Orders", OtherKey = "CustomerID")]
    public EntitySet<Order> Orders
    {
        get { return this._Orders; }
        set { this._Orders.Assign(value); }
    }
}
// </Snippet3>

// <Snippet4>
[Table]
[InheritanceMapping(Code = "C", Type = typeof(Car))]
[InheritanceMapping(Code = "T", Type = typeof(Truck))]
[InheritanceMapping(Code = "V", Type = typeof(Vehicle),
    IsDefault = true)]
public class Vehicle
{
    [Column(IsDiscriminator = true)]
    public string DiscKey;
    [Column(IsPrimaryKey = true)]
    public string VIN;
    [Column]
    public string MfgPlant;
}
public class Car : Vehicle
{
    [Column]
    public int TrimCode;
    [Column]
    public string ModelName;
}

public class Truck : Vehicle
{
    [Column]
    public int Tonnage;
    [Column]
    public int Axles;
}
// </Snippet4>

// <Snippet5>
[Table(Name = "Orders")]
public class Order
{
    [Column(IsPrimaryKey = true)]
    public int OrderID;
    [Column]
    public string CustomerID;
    private EntityRef<Customer> _Customer;
    [Association(Storage = "_Customer", ThisKey = "CustomerID")]
    public Customer Customer
    {
        get { return this._Customer.Entity; }
        set { this._Customer.Entity = value; }
    }
}
// </Snippet5>
