using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace ServiceModel.Samples
{
    //<snippet1>
    [DataContract]
    public class Person
    {
        // Code not shown.
    }

    [DataContract]
    public class PurchaseOrder
    {
        // Code not shown.
    }
    //</snippet1>

    public class Test
    {
        private void Run()
        {
            //<snippet2>
            DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
            // This can now be used to serialize/deserialize Person but not PurchaseOrder.
            //</snippet2>
        }
        //<snippet3>
        [DataContract]
        public class LibraryPatron
        {
            [DataMember]
            public LibraryItem[] borrowedItems;
        }
        [DataContract]
        public class LibraryItem
        {
            // Code not shown.
        }

        [DataContract]
        public class Book : LibraryItem
        {
            // Code not shown.
        }

        [DataContract]
        public class Newspaper : LibraryItem
        {
            // Code not shown.
        }
        //</snippet3>

        private void Run2()
        {
            //<snippet4>
            // Create a serializer for the inherited types using the knownType parameter.
            Type[] knownTypes = new Type[] { typeof(Book), typeof(Newspaper) };
            DataContractSerializer dcs =
            new DataContractSerializer(typeof(LibraryPatron), knownTypes);
            // All types are known after construction.
            //</snippet4>
        }
    }

    //<snippet5>
    [DataContract(Name = "PersonContract", Namespace = "http://schemas.contoso.com")]
    public class Person2
    {
        [DataMember(Name = "AddressMember")]
        public Address theAddress;
    }

    [DataContract(Name = "AddressContract", Namespace = "http://schemas.contoso.com")]
    public class Address
    {
        [DataMember(Name = "StreetMember")]
        public string street;
    }
    //</snippet5>

    public class Test2
    {
        private void Serialize(string path)
        {
            FileStream someStream = new FileStream(path, FileMode.Open);

            //<snippet8>
            Person p = new Person();
            DataContractSerializer dcs =
                new DataContractSerializer(typeof(Person));
            XmlDictionaryWriter xdw =
                XmlDictionaryWriter.CreateTextWriter(someStream,Encoding.UTF8 );
            dcs.WriteObject(xdw, p);
            //</snippet8>

            //<snippet9>
            dcs.WriteStartObject(xdw, p);
            xdw.WriteAttributeString("serializedBy", "myCode");
            dcs.WriteObjectContent(xdw, p);
            dcs.WriteEndObject(xdw);
            //</snippet9>

            //<snippet10>
            xdw.WriteStartElement("MyCustomWrapper");
            dcs.WriteObjectContent(xdw, p);
            xdw.WriteEndElement();
            //</snippet10>
        }

        private void Deserialize(string path)
        {
            //<snippet11>
            DataContractSerializer dcs = new DataContractSerializer(typeof(Person));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
            XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            Person p = (Person)dcs.ReadObject(reader);
            //</snippet11>
        }
    }

    namespace ServiceModelSamples2
    {
        public class Test
        {
            private void Run()
            {
                //<snippet7>
                // Construct a purchase order:
                Address adr = new Address();
                adr.street = "123 Main St.";
                PurchaseOrder po = new PurchaseOrder();
                po.billTo = adr;
                po.shipTo = adr;
                //</snippet7>
            }

            private void CheckNodeType(string path)
            {
                //<snippet12>
                DataContractSerializer ser = new DataContractSerializer(typeof(Person),
                "Customer", @"http://www.contoso.com");
                FileStream fs = new FileStream(path, FileMode.Open);
                XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (ser.IsStartObject(reader))
                            {
                                Console.WriteLine("Found the element");
                                Person p = (Person)ser.ReadObject(reader);
                                Console.WriteLine("{0} {1}    id:{2}",
                                    p.Name , p.Address);
                            }
                            Console.WriteLine(reader.Name);
                            break;
                    }
                }
                //</snippet12>
            }
        }

        //<snippet6>
        [DataContract]
        public class PurchaseOrder
        {
            [DataMember]
            public Address billTo;
            [DataMember]
            public Address shipTo;
        }

        [DataContract]
        public class Address
        {
            [DataMember]
            public string street;
        }
        //</snippet6>

        public class Person
        {
            public string Name;
            public string Address;
        }
    }
}
