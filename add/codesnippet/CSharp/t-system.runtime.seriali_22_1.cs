using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

// You must apply a DataContractAttribute or SerializableAttribute
// to a class to have it serialized by the DataContractSerializer.
[DataContract()]
class Person : IExtensibleDataObject
{
    private string LastNameValue;
    // Apply the DataMemberAttribute to fields (or properties) 
    // that must be serialized.
    [DataMember()]
    public string FirstName;

    [DataMember]
    public string LastName
    {
        get { return LastNameValue; }
        set { LastNameValue = value; }
    }

    [DataMember(Name = "ID")]
    public int IdNumber;

    // Note that you can apply the DataMemberAttribute to 
    // a private field as well.
    [DataMember]
    private string Secret;

    public Person(string newfName, string newLName, int newIdNumber)
    {
        FirstName = newfName;
        LastName = newLName;
        IdNumber = newIdNumber;
        Secret = newfName + newLName + newIdNumber;
    }

    // The extensionDataValue field holds data from future versions 
    // of the type.  This enables this type to be compatible with 
    // future versions. The field is required to implement the 
    // IExtensibleDataObject interface.

    private ExtensionDataObject extensionDatavalue;

    public ExtensionDataObject ExtensionData
    {
        get
        {
            return extensionDatavalue;
        }
        set
        {
            extensionDatavalue = value;
        }
    }
}

public class Test
{
    public static void Main(string[] args)
    {
        try
        {
            WriteObject(@"DataMemberAttributeExample.xml");
            ReadObject(@"DataMemberAttributeExample.xml");
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

    public static void WriteObject(string filename)
    {
        // Create a new instance of the Person class.
        Person p1 = new Person("Zighetti", "Barbara", 101);
        FileStream writer = new FileStream(filename,
        FileMode.OpenOrCreate);
        DataContractSerializer ser =
            new DataContractSerializer(typeof(Person));
        ser.WriteObject(writer, p1);
        writer.Close();
    }

    public static void ReadObject(string filename)
    {
        // Deserialize an instance of the Person class 
        // from an XML file.
        FileStream fs = new FileStream(filename,
        FileMode.OpenOrCreate);
        DataContractSerializer ser =
            new DataContractSerializer(typeof(Person));
        // Deserialize the data and read it from the instance.
        Person deserializedPerson = (Person)ser.ReadObject(fs);
        fs.Close();
        Console.WriteLine(String.Format("{0} {1}, ID: {2}",
        deserializedPerson.FirstName, deserializedPerson.LastName,
        deserializedPerson.IdNumber));
    }

}