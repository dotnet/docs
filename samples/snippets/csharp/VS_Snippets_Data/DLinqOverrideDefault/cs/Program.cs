using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace cs_overridedefault
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    // <Snippet3>
    public partial class Customer
    {
        partial void OnAddressChanged();
        partial void OnAddressChanged()
        {
            // Insert business logic here.
        }
    }
    // </Snippet3>
}
