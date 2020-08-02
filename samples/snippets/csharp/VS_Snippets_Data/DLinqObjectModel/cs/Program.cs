using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace cs_objectmodel
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    // <Snippet1>
    [Table(Name = "Customers")]
    public class Customerzz
    {
        public string CustomerID;
        // ...
        public string City;
    }
    // </Snippet1>

    // <Snippet2>
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column(IsPrimaryKey = true)]
        public string CustomerID;
        [Column]
        public string City;
    }
    // </Snippet2>
}
