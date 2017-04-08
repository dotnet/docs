using System.Security.Permissions;
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace IExtensibleDataObjectExample
{
    //<snippet0>
    using System;
    using System.Xml;
    using System.Runtime.Serialization;
    using System.IO;
    
    //<snippet1>
    // Implement the IExtensibleDataObject interface 
    // to store the extra data for future versions.
    [DataContract(
        Name = "Person",
        Namespace = "http://www.cohowinery.com/employees")]
    class Person : IExtensibleDataObject
    {
        // To implement the IExtensibleDataObject interface,
        // you must implement the ExtensionData property. The property
        // holds data from future versions of the class for backward
        // compatibility.
        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
        [DataMember]
        public string Name;
    }

    // The second version of the class adds a new field. The field's 
    // data is stored in the ExtensionDataObject field of
    // the first version (Person). You must also set the Name property 
    // of the DataContractAttribute to match the first version. 
    // If necessary, also set the Namespace property so that the 
    // name of the contracts is the same.
    [DataContract(Name = "Person",
        Namespace = "http://www.cohowinery.com/employees")]
    class PersonVersion2 : IExtensibleDataObject
    {
        // Best practice: add an Order number to new members.
        [DataMember(Order=2)]
        public int ID;

        [DataMember]
        public string Name;

        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
    }
    //</snippet1>
    public sealed class Program
    {
        private Program()
        {
            // Private constructor to prevent creation of this class.
        }

        public static void Main()
        {
            try
            {
                WriteVersion2("V2.xml");
                WriteToVersion1("v2.xml");
                ReadVersion2("v2.xml");
            }
            catch (SerializationException exc)
            {
                Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        // Create an instance of the version 2.0 class. It has  
        // extra data (ID field) that version 1.0 does 
        // not understand.
        static void WriteVersion2(string path)
        {
            Console.WriteLine("Creating a version 2 object");
            PersonVersion2 p2 = new PersonVersion2();
            p2.Name = "Elizabeth";
            p2.ID = 2006;

            Console.WriteLine("Object data includes an ID");
            Console.WriteLine("\t Name: {0}", p2.Name);
            Console.WriteLine("\t ID: {0} \n", p2.ID);
            // Create an instance of the DataContractSerializer.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(PersonVersion2));

            Console.WriteLine("Serializing the v2 object to a file. \n\n");
            FileStream fs = new FileStream(path, FileMode.Create);
            ser.WriteObject(fs, p2);
            fs.Close();
        }

        // Deserialize version 2 data to a version 1 object.
        static void WriteToVersion1(string path)
        {
            // Create the serializer using the version 1 type.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));

            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader =
               XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            Console.WriteLine
                ("Deserializing v2 data to v1 object. \n\n");

            Person p1 = (Person)ser.ReadObject(reader, false);

            Console.WriteLine("V1 data has only a Name field.");
            Console.WriteLine("But the v2 data is stored in the ");
            Console.WriteLine("ExtensionData property. \n\n");
            Console.WriteLine("\t Name: {0} \n", p1.Name);

            fs.Close();

            // Change data in the object.
            p1.Name = "John";
            Console.WriteLine("Changed the Name value to 'John' ");
            Console.Write("and reserializing the object to version 2 \n\n");
            // Reserialize the object.
            fs = new FileStream(path, FileMode.Create);
            ser.WriteObject(fs, p1);
            fs.Close();
        }

        // Deserialize a version 2.0 object. 
        public static void ReadVersion2(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            DataContractSerializer ser = new DataContractSerializer(typeof(PersonVersion2));

            Console.WriteLine("Deserializing new data to version 2 \n\n");
            PersonVersion2 p2 = (PersonVersion2)ser.ReadObject(fs);
            fs.Close();

            Console.WriteLine("The data includes the old ID field value. \n");
            Console.WriteLine("\t (New) Name: {0}", p2.Name);
            Console.WriteLine("\t ID: {0} \n", p2.ID);
        }
    }
    //</snippet0>
}