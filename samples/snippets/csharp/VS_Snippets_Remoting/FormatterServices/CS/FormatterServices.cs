//Types:System.Runtime.Serialization.FormatterServices Vendor: Richter
//Types:System.Runtime.Serialization.SerializationInfoEnumerator  Vendor: Richter
//<snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Security.Permissions;


// Person is a serializable base class.
[Serializable]
public class Person
{
    private String title;

    public Person(String title)
    {
        this.title = title;
    }

    public override String ToString()
    {
        return String.Format("{0}", title);
    }
}

// Employee is a serializable class derived from Person.
[Serializable]
public class Employee : Person
{
    private String title;

    public Employee(String title) : base("Person")
    {
        this.title = title;
    }

    public override String ToString()
    {
        return String.Format("{0} -> {1}", title, base.ToString());
    }
}

// Manager is a serializable and ISerializable class derived from Employee.
[Serializable]
public class Manager : Employee, ISerializable
{
    private String title;

    public Manager() : base("Employee") 
    {
        this.title = "Manager";
    }

    //<snippet2> 
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {

        // Serialize the desired values for this class.
        info.AddValue("title", title);

        // Get the set of serializable members for the class and base classes.
        Type thisType = this.GetType();
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

        // Serialize the base class's fields to the info object.
        for (Int32 i = 0; i < mi.Length; i++)
        {
            // Do not serialize fields for this class.
            if (mi[i].DeclaringType == thisType) continue;

            // Skip this field if it is marked NonSerialized.
            if (Attribute.IsDefined(mi[i], typeof(NonSerializedAttribute))) continue;
         
            // Get the value of this field and add it to the SerializationInfo object.
            info.AddValue(mi[i].Name, ((FieldInfo) mi[i]).GetValue(this));
        }

        // Call the method below to see the contents of the SerializationInfo object.
        DisplaySerializationInfo(info);
    }
    //</snippet2>
 
    //<snippet3>
    private void DisplaySerializationInfo(SerializationInfo info)
    {
        SerializationInfoEnumerator e = info.GetEnumerator();
        Console.WriteLine("Values in the SerializationInfo:");
        while (e.MoveNext())
        {
            Console.WriteLine("Name={0}, ObjectType={1}, Value={2}", e.Name, e.ObjectType, e.Value);
        }
    }
    //</snippet3>

    [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.SerializationFormatter)]
    protected Manager(SerializationInfo info, StreamingContext context) : base(null)
    {

        // Get the set of serializable members for the class and base classes.
        Type thisType = this.GetType();
        MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

        // Deserialize the base class's fields from the info object.
        for (Int32 i = 0; i < mi.Length; i++)
        {
            // Do not deserialize fields for this class.
            if (mi[i].DeclaringType == thisType) continue;

            // For easier coding, treat the member as a FieldInfo object
            FieldInfo fi = (FieldInfo) mi[i];

            // Skip this field if it is marked NonSerialized.
            if (Attribute.IsDefined(mi[i], typeof(NonSerializedAttribute))) continue;

            // Get the value of this field from the SerializationInfo object.
            fi.SetValue(this, info.GetValue(fi.Name, fi.FieldType));
        }

        // Deserialize the values that were serialized for this class.
        title = info.GetString("title");
    }

    public override String ToString()
    {
        return String.Format("{0} -> {1}", title, base.ToString());
    }
}


public sealed class App
{
    public static void Main()
    {
        Run();
    }

    public static void Run()
    {
        using (Stream stream = new MemoryStream())
	{
            IFormatter formatter = new BinaryFormatter();
            Manager m = new Manager();
            Console.WriteLine(m.ToString());
            formatter.Serialize(stream, m);

            stream.Position = 0;
            m = (Manager) formatter.Deserialize(stream);
            Console.WriteLine(m.ToString());
        }
    }
}
// This code produces the following output.
//
//  Manager -> Employee -> Person
//  Values in the SerializaitonInfo:
//  Name=title, ObjectType=System.String, Value=Manager
//  Name=Employee+title, ObjectType=System.String, Value=Employee
//  Name=Person+title, ObjectType=System.String, Value=Person
//  Manager -> Employee -> Person
//</snippet1>