using System;
using System.Collections.ObjectModel;
using System.CodeDom;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Security.Permissions;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;

[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]

namespace DataContractSerializerExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;
    //<snippet0>
    // You must apply a DataContractAttribute or SerializableAttribute
    // to a class to have it serialized by the NetDataContractSerializer.
    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    class Person : IExtensibleDataObject
    {
        [DataMember()]
        public string FirstName;
        [DataMember]
        public string LastName;
        [DataMember()]
        public int ID;

        public Person(string newfName, string newLName, int newID)
        {
            FirstName = newfName;
            LastName = newLName;
            ID = newID;
        }

        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionData_Value;
            }
            set
            {
                extensionData_Value = value;
            }
        }
    }

    public sealed class Test
    {
        private Test() { }

        public static void Main()
        {
            try
            {
                WriteObject("NetDataContractSerializerExample.xml");
                ReadObject("NetDataContractSerializerExample.xml");
            }

            catch (SerializationException serExc)
            {
                Console.WriteLine("Serialization Failed");
                Console.WriteLine(serExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(
                "The serialization operation failed: {0} StackTrace: {1}",
                exc.Message, exc.StackTrace);
            }

            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }

        //<snippet1>
        public static void WriteObject(string fileName)
        {
            Console.WriteLine(
                "Creating a Person object and serializing it.");
            Person p1 = new Person("Zighetti", "Barbara", 101);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            ser.WriteObject(writer, p1);
            writer.Close();
        }
        //</snippet1>

        //<snippet2>
        public static void ReadObject(string fileName)
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            NetDataContractSerializer ser = new NetDataContractSerializer();

            // Deserialize the data and read it from the instance.
            Person deserializedPerson =
                (Person)ser.ReadObject(reader, true);
            fs.Close();
            Console.WriteLine(String.Format("{0} {1}, ID: {2}",
            deserializedPerson.FirstName, deserializedPerson.LastName,
            deserializedPerson.ID));
        }
        //</snippet2>
    }
    //</snippet0>

    //<snippet3>
    [DataContract]
    public class GetCurrency : IExtensibleDataObject
    {
        [DataMemberAttribute]
        private string Country_value;
        public string Country
        {
            get { return Country_value; }
            set { Country_value = value; }
        }

        // Note that this field is not serialized. Instead, it is 
        // populated after serialization.
        private string Currency_value;
        public string Currency
        {
            get { return Currency_value; }
            set { Currency_value = value; }
        }

        // Use this method to look up the country/region and set 
        // the Currency field after deserialization.
        [OnDeserialized]
        private void GetLocalRate(StreamingContext sc)
        {
            if (this.Country == "Japan")
                this.Currency = "Yen";
        }

        // Implement the IExensibleDataObject interface to 
        // retain future version information.
        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get { return extensionData_Value; }
            set { extensionData_Value = value; }
        }
    }
    //</snippet3>


    //<snippet4>
    [DataContract(Name = "PurchaseOrder", Namespace = "urn:www.Microsoft.com")]
    public class PurchaseOrder : IExtensibleDataObject
    {
        private DateTime purchaseDate_value;

        [DataMember]
        public DateTime PurchaseDate
        {
            get { return purchaseDate_value; }
            set { purchaseDate_value = value; }
        }

        private ExtensionDataObject extensionData_value;

        public ExtensionDataObject ExtensionData
        {
            get { return extensionData_value; }
            set { extensionData_value = value; }
        }
    }

    [DataContract(Name = "PurchaseOrder", Namespace = "urn:www.Microsoft.com")]
    public class PurchaseOrderV2 : IExtensibleDataObject
    {
        private DateTime purchaseDate_value;
        [DataMember]
        public DateTime PurchaseDate
        {
            get { return purchaseDate_value; }
            set { purchaseDate_value = value; }
        }

        [DataMember]
        private int purchaseOrderId_value;

        public int PurchaseOrderId
        {
            get { return purchaseOrderId_value; }
            set { purchaseOrderId_value = value; }
        }

        private ExtensionDataObject extensionData_value;

        public ExtensionDataObject ExtensionData
        {
            get { return extensionData_value; }
            set { extensionData_value = value; }
        }
    }

    public sealed class TestFutureCompatibleTypes
    {
        private TestFutureCompatibleTypes() { }

        public static void RunTest()
        {
            SerializeNewVersion("myTestFile.xml");
            DeserializeAndReserialize("myTestFile.xml");
            DeserializeToNewVersion("myTestFile.xml");
            Console.ReadLine();
        }
        static void SerializeNewVersion(string path)
        {
            Console.WriteLine("Serializing new version of a contract.");
            FileStream fs = new FileStream(path,
                FileMode.Create);
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            PurchaseOrderV2 PO_V2 = new PurchaseOrderV2();
            PO_V2.PurchaseDate = DateTime.Now;
            PO_V2.PurchaseOrderId = 1234;
            ser.WriteObject(fs, PO_V2);
            fs.Close();
            Console.WriteLine("Order Date: {0}",
                PO_V2.PurchaseDate.ToLongDateString());
            Console.WriteLine("Order ID:{0}", PO_V2.PurchaseOrderId);
        }
        static void DeserializeAndReserialize(string path)
        {
            Console.WriteLine(
                "Deserializing new version to old version");
            FileStream fs = new FileStream(path,
                FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.
                CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the serializer.
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            // Deserialize version 1 of the data.
            PurchaseOrder PO_V1 =
                (PurchaseOrder)ser.ReadObject(reader, false);
            Console.WriteLine("Order Date:{0}",
                PO_V1.PurchaseDate.ToLongDateString());
            fs.Close();

            Console.WriteLine(
                "Reserialize the object with extension data intact");
            // First change the order date.
            DateTime newDate = PO_V1.PurchaseDate.AddDays(10);
            PO_V1.PurchaseDate = newDate;

            // Create a new FileStream to write with.
            FileStream writer = new FileStream(path, FileMode.Create);
            // Serialize the object with changed data.
            ser.WriteObject(writer, PO_V1);
            writer.Close();
        }
        static void DeserializeToNewVersion(string path)
        {
            Console.WriteLine
                ("Deserializing to new version, extension data intact");
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            PurchaseOrderV2 newOrder =
                (PurchaseOrderV2)ser.ReadObject(reader, false);
            Console.WriteLine("Original OrderID: {0}", newOrder.PurchaseOrderId);
            Console.WriteLine("New Order Date: {0}",
                newOrder.PurchaseDate.ToLongDateString());
            fs.Close();
        }
    }
    //</snippet4>


    //<snippet5>
    public sealed class ShowWriteStartObject
    {

        public static void WriteObjectData(string path)
        {
            // Create the object to serialize.
            Person p = new Person("Lynn", "Tsoflias", 9876);

            // Create the writer.
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlDictionaryWriter writer =
                XmlDictionaryWriter.CreateTextWriter(fs);

            NetDataContractSerializer ser =
                new NetDataContractSerializer();

            // Use the writer to start a document.
            writer.WriteStartDocument(true);

            // Use the serializer to write the start of the 
            // object data. Use it again to write the object
            // data. 
            ser.WriteStartObject(writer, p);
            ser.WriteObjectContent(writer, p);

            // Use the serializer to write the end of the 
            // object data. Then use the writer to write the end
            // of the document.
            ser.WriteEndObject(writer);
            writer.WriteEndDocument();

            Console.WriteLine("Done");

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }
        //</snippet5>

        //<snippet6>
        public static void ReadObjectData(string path)
        {
            // Create the reader.
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the NetDataContractSerializer, specifying the type, 
            // root, and namespace to use. The root value corresponds
            // to the DataContract.Name value, and the namespace value
            // corresponds to the DataContract.Namespace value.
            NetDataContractSerializer ser =
                new NetDataContractSerializer();

            // Test whether the serializer is on the start of the 
            // object data. If so, read the data and write it 
            // to the console.
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
                                p.FirstName, p.LastName, p.ID);
                        }
                        Console.WriteLine(reader.Name);
                        break;
                }

            }
            fs.Flush();
            fs.Close();
        }
        //</snippet6>

        //<snippet7>
        public static void WriteObjectContentInDocument(string path)
        {
            // Create the object to serialize.
            Person p = new Person("Lynn", "Tsoflias", 9876);

            // Create the writer.
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlDictionaryWriter writer =
                XmlDictionaryWriter.CreateTextWriter(fs);

            NetDataContractSerializer ser =
                new NetDataContractSerializer();

            // Use the writer to start a document.
            writer.WriteStartDocument(true);
            // Use the writer to write the root element.
            writer.WriteStartElement("Company");
            // Use the writer to write an element.
            writer.WriteElementString("Name", "Microsoft");
            // Use the serializer to write the start, content,
            // and end data.
            ser.WriteStartObject(writer, p);
            writer.WriteStartAttribute("localName");
            writer.WriteString("My Value");
            writer.WriteEndAttribute();
            ser.WriteObjectContent(writer, p);
            ser.WriteEndObject(writer);

            // Use the writer to write the end element 
            // and end of the document.
            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }
        //</snippet7>

        //<snippet8>
        public static void Constructor1()
        {
            // Create an instance of the NetDataContractSerializer.
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            // Other code not shown.
        }
        //</snippet8>

        //<snippet9>
        public static void Constructor2()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);
            // Create a DatatContractSerializer with the collection.
            NetDataContractSerializer ser2 = new NetDataContractSerializer(sc);

            // Other code not shown.
        }
        //</snippet9>

        //<snippet10>
        public static void Constructor3()
        {
            // Create an instance of the NetDataContractSerializer
            // specifying the name and namespace as strings.
            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                "Customer",
                "http://www.contoso.com");
            // Other code not shown.
        }
        //</snippet10>

        //<snippet11>
        public static void Constructor4()
        {
            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            // Initialize the out variables.
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create the serializer.
            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                name_value,
                ns_value);
            // Other code not shown.
        }
        //</snippet11>

        //<snippet12>
        public static void Constructor5()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);

            // Create an instance of a class that implements the 
            // ISurrogateSelector interface. The implementation code
            // is not shown here.
            MySelector mySurrogateSelector = new MySelector();

            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                sc,
                int.MaxValue,
                true,
                FormatterAssemblyStyle.Simple,
                mySurrogateSelector);

            // Other code not shown.
        }
        //</snippet12>

        //<snippet13>
        public static void Constructor6()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);

            // Create an instance of a class that implements the 
            // ISurrogateSelector interface. The implementation code
            // is not shown here.
            MySelector mySurrogateSelector = new MySelector();

            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                "Customer",
                "http://www.contoso.com",
                sc,
                int.MaxValue,
                true,
                FormatterAssemblyStyle.Simple,
                mySurrogateSelector);
            // Other code not shown.            
        }
        //</snippet13>

        //<snippet14>
        public static void Constructor7()
        {
            // Create an instance of the StreamingContext to hold
            // context data.
            StreamingContext sc = new StreamingContext
                (StreamingContextStates.CrossAppDomain);

            // Create an XmlDictionary and add values to it.
            XmlDictionary d = new XmlDictionary();
            XmlDictionaryString name_value = d.Add("Customer");
            XmlDictionaryString ns_value = d.Add("http://www.contoso.com");

            // Create an instance of a class that implements the 
            // ISurrogateSelector interface. The implementation code
            // is not shown here.
            MySelector mySurrogateSelector = new MySelector();

            NetDataContractSerializer ser =
                new NetDataContractSerializer(
                name_value,
                ns_value,
                sc,
                int.MaxValue,
                true,
                FormatterAssemblyStyle.Simple,
                mySurrogateSelector);

            // Other code not shown.
        }
        //</snippet14>

        public void CannotSerialize()
        {

            //<snippet15>
            FileStream fs = new FileStream("mystuff.xml", FileMode.Create, FileAccess.ReadWrite);
            XElement myElement = new XElement("Parent", new XElement("child1", "form"),
                new XElement("child2", "base"),
                new XElement("child3", "formbase")
                );
            NetDataContractSerializer dcs = new NetDataContractSerializer();
            dcs.WriteObject(fs, myElement);
            //</snippet15>
        }

    }

    [DataContract]
    public class Orders
    {
        public Orders()
        {
            this.OrderCollection = new Hashtable();
        }
        [DataMember]
        internal Hashtable OrderCollection;
    }

    [DataContract]
    public class PurchaseOrderV3
    {
        [DataMember]
        internal DateTime PurchaseDate;
        [DataMember]
        internal int OrderId;
    }

    public class DCSurrogate : IDataContractSurrogate
    {
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return new Person("Lynne", "Tsofilas", 1);
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        { return new Person("Lynne", "Tsofilas", 1); }
        public Type GetDataContractType(Type type)
        {
            return typeof(Person);
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return new Person("Lynne", "Tsofilas", 1);
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            customDataTypes.Add(typeof(PurchaseOrder));
            customDataTypes.Add(typeof(PurchaseOrderV3));
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            return new Person("Lynne", "Tsofilas", 1);
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return typeof(Person);
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return new CodeTypeDeclaration();
        }
    }

    internal class MySelector : ISurrogateSelector
    {
        public void ChainSelector(ISurrogateSelector selector)
        {

        }
        public ISurrogateSelector GetNextSelector()
        {
            return new PersonSurrogateSelector();
        }
        public ISerializationSurrogate GetSurrogate(Type type,
            StreamingContext context, out ISurrogateSelector selector)
        {
            if (type.GetType() == typeof(Person))
            {
                selector = new MySelector();
                return new MySerializationSurrogate();
            }
            else
            {
                selector = new MySelector();
                return new MySerializationSurrogate();

            }
        }

        internal class PersonSurrogateSelector : ISurrogateSelector
        {
            public void ChainSelector(ISurrogateSelector selector) { }
            public ISurrogateSelector GetNextSelector()
            {
                return new PersonSurrogateSelector();
            }

            [SecurityPermission(SecurityAction.LinkDemand, Flags
                   = SecurityPermissionFlag.SerializationFormatter)]
            public ISerializationSurrogate GetSurrogate(Type type,
                StreamingContext context, out ISurrogateSelector selector)
            {
                selector = new MySelector();
                return new MySerializationSurrogate();
            }
        }

        internal class MySerializationSurrogate : ISerializationSurrogate
        {
            public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
            { }
            public object SetObjectData(object obj, SerializationInfo info,
                StreamingContext context, ISurrogateSelector selector)
            {
                return new object();

            }

        }
    }
}
