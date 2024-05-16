using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Security.Permissions;
//<snippet1>
namespace DataContractAttributeExample
{
    // Set the Name and Namespace properties to new values.
    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    class Person : IExtensibleDataObject
    {
        // To implement the IExtensibleDataObject interface, you must also
        // implement the ExtensionData property.
        private ExtensionDataObject extensionDataObjectValue;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObjectValue;
            }
            set
            {
                extensionDataObjectValue = value;
            }
        }

        [DataMember(Name = "CustName")]
        internal string Name;

        [DataMember(Name = "CustID")]
        internal int ID;

        public Person(string newName, int newID)
        {
            Name = newName;
            ID = newID;
        }
    }

    class Test
    {
        public static void Main()
        {
            try
            {
                WriteObject("DataContractExample.xml");
                ReadObject("DataContractExample.xml");
                Console.WriteLine("Press Enter to end");
                Console.ReadLine();
            }
            catch (SerializationException se)
            {
                Console.WriteLine
                ("The serialization operation failed. Reason: {0}",
                  se.Message);
                Console.WriteLine(se.Data);
                Console.ReadLine();
            }
        }

        public static void WriteObject(string path)
        {
            // Create a new instance of the Person class and
            // serialize it to an XML file.
            Person p1 = new Person("Mary", 1);
            // Create a new instance of a StreamWriter
            // to read and write the data.
            FileStream fs = new FileStream(path,
            FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));
            ser.WriteObject(writer, p1);
            Console.WriteLine("Finished writing object.");
            writer.Close();
            fs.Close();
        }
        public static void ReadObject(string path)
        {
            // Deserialize an instance of the Person class
            // from an XML file. First create an instance of the
            // XmlDictionaryReader.
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            // Create the DataContractSerializer instance.
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));

            // Deserialize the data and read it from the instance.
            Person newPerson = (Person)ser.ReadObject(reader);
            Console.WriteLine("Reading this object:");
            Console.WriteLine(String.Format("{0}, ID: {1}",
            newPerson.Name, newPerson.ID));
            fs.Close();
        }
    }
}
//</snippet1>
namespace NewDataStuff
{
    //<snippet2>
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Person
    {
        // This member is serialized.
        [DataMember]
        internal string FullName;

        // This is serialized even though it is private.
        [DataMember]
        private int Age;

        // This is not serialized because the DataMemberAttribute
        // has not been applied.
        private string MailingAddress;

        // This is not serialized, but the property is.
        private string telephoneNumberValue;

        [DataMember]
        public string TelephoneNumber
        {
            get { return telephoneNumberValue; }
            set { telephoneNumberValue = value; }
        }
    }
    //</snippet2>
}

namespace SecurityConsiderations
{
    //<snippet3>
    [DataContract]
    public class SpaceStationAirlock
    {
        [DataMember]
        private bool innerDoorOpenValue = false;
        [DataMember]
        private bool outerDoorOpenValue = false;

        public bool InnerDoorOpen
        {
            get { return innerDoorOpenValue; }
            set
            {
                if (value & outerDoorOpenValue)
                    throw new Exception("Cannot open both doors!");
                else innerDoorOpenValue = value;
            }
        }
        public bool OuterDoorOpen
        {
            get { return outerDoorOpenValue; }
            set
            {
                if (value & innerDoorOpenValue)
                    throw new Exception("Cannot open both doors!");
                else outerDoorOpenValue = value;
            }
        }
    }
    //</snippet3>
}

namespace XmlAndADOTypes
{
    //<snippet4>
    [DataContract(Namespace=@"http://schemas.contoso.com")]
    public class MyDataContract
    {
        [DataMember]
        public XmlElement myDataMember;
        public void TestClass()
        {
            XmlDocument xd = new XmlDocument();
            myDataMember = xd.CreateElement("myElement");
            myDataMember.InnerText = "myContents";
            myDataMember.SetAttribute
             ("myAttribute","myValue");
        }
    }
    //</snippet4>
}

namespace XmlAndADO2
{
    //<snippet5>
    [DataContract(Namespace="http://schemas.contoso.com")]
    public class MyDataContract
    {
        [DataMember]
        public XmlNode[] myDataMember = new XmlNode[4];
        public void TestClass()
        {
            XmlDocument xd = new XmlDocument();
            XmlElement xe = xd.CreateElement("myElement");
            xe.InnerText = "myContents";
            xe.SetAttribute
             ("myAttribute","myValue");
		
            XmlAttribute atr = xe.Attributes[0];
            XmlComment cmnt = xd.CreateComment("myComment");
			
		  myDataMember[0] = atr;
		  myDataMember[1] = cmnt;
		  myDataMember[2] = xe;
		  myDataMember[3] = xe;
        }
    }
    //</snippet5>
}
