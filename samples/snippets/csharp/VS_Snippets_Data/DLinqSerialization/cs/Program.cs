using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Xml;

namespace cs_serialize
{
    class Program
    {
        static void Main(string[] args)
        {
// <Snippet6>
Northwnd db = new Northwnd(@"c\northwnd.mdf");

Customer cust = db.Customers.Where(c => c.CustomerID ==
    "ALFKI").Single();

DataContractSerializer dcs =
    new DataContractSerializer(typeof(Customer));
StringBuilder sb = new StringBuilder();
XmlWriter writer = XmlWriter.Create(sb);
dcs.WriteObject(writer, cust);
writer.Close();
string xml = sb.ToString();
// </Snippet6>
        }
    }
}
