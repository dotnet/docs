//<snippet0>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;

namespace GeneratPathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the type of the class that defines the data contract.
            Type t = typeof(Order);

            // Get the meta data for the specific members to be used in the query.
            MemberInfo[] mi = t.GetMember("Product");
            MemberInfo[] mi2 = t.GetMember("Value");
            MemberInfo[] mi3 = t.GetMember("Quantity");

            // Call the function below to generate and display the query.
            GenerateXPath(t, mi);
            GenerateXPath(t, mi2);
            GenerateXPath(t, mi3);


            // Get the type of the second class that defines a data contract.
            Type t2 = typeof(Line);

            // Get the meta data for the member to be used in the query.
            MemberInfo[] mi4 = t2.GetMember("Items");
            
            GenerateXPath(t2, mi4);

            Console.ReadLine();
        }

        static void GenerateXPath(Type t, MemberInfo[] mi)
        {

            // Create a new name table and name space manager.
            NameTable nt = new NameTable();
            XmlNamespaceManager xname = new XmlNamespaceManager(nt);


            // Generate the query and print it.
            string query = XPathQueryGenerator.CreateFromDataContractSerializer(
                t, mi, out xname);
            Console.WriteLine(query);
            Console.WriteLine();


            // Display the namespaces and prefixes used in the data contract.
            foreach (string s in xname)
                Console.WriteLine("{0}  = {1}", s, xname.LookupNamespace(s));
           
            Console.WriteLine();       

        }
    }

    [DataContract(Namespace = "http://www.cohowinery.com/")]
    public class Line
    {
        private Order[] itemsValue;

        [DataMember]
        public Order[] Items
        {
            get { return itemsValue; }
            set { itemsValue = value; }
        }

    }

    [DataContract(Namespace = "http://contoso.com")]
    public class Order
    {
        private string productValue;
        private int quantityValue;
        private decimal valueValue;

        [DataMember(Name = "cost")]
        public decimal Value
        {
            get { return valueValue; }
            set { valueValue = value; }
        }

        [DataMember(Name = "quantity")]
        public int Quantity
        {
            get { return quantityValue; }
            set { quantityValue = value; }
        }

        [DataMember(Name = "productName")]
        public string Product
        {
            get { return productValue; }
            set { productValue = value; }
        }
    }
}
//</snippet0>