//<snippet1>
using System;
using System.Web;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Permissions;


// There should be only one instance of this type per AppDomain.
[Serializable]
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
[AspNetHostingPermission(SecurityAction.LinkDemand, 
    Level=AspNetHostingPermissionLevel.Minimal)]
public sealed class Singleton : ISerializable 
{
    // This is the one instance of this type.
    private static readonly Singleton theOneObject = new Singleton();

    // Here are the instance fields.
    private string someString_value;
    private Int32 someNumber_value;

   public string SomeString
   {
       get{return someString_value;}
       set{someString_value = value;}
   }

   public Int32 SomeNumber
   {
       get{return someNumber_value;}
       set{someNumber_value = value;}
   }

    // Private constructor allowing this type to construct the Singleton.
    private Singleton() 
    { 
        // Do whatever is necessary to initialize the Singleton.
        someString_value = "This is a string field";
        someNumber_value = 123;
    }

    // A method returning a reference to the Singleton.
    public static Singleton GetSingleton() 
    { 
        return theOneObject; 
    }

    // A method called when serializing a Singleton.
   [SecurityPermissionAttribute(SecurityAction.LinkDemand, 
   Flags=SecurityPermissionFlag.SerializationFormatter)]
    void ISerializable.GetObjectData(
        SerializationInfo info, StreamingContext context) 
    {
        // Instead of serializing this object, 
        // serialize a SingletonSerializationHelp instead.
        info.SetType(typeof(SingletonSerializationHelper));
        // No other values need to be added.
    }

    // Note: ISerializable's special constructor is not necessary 
    // because it is never called.
}


[Serializable]
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
[SecurityPermissionAttribute(SecurityAction.LinkDemand, 
    Flags=SecurityPermissionFlag.SerializationFormatter)]
[AspNetHostingPermission(SecurityAction.LinkDemand, 
   Level=AspNetHostingPermissionLevel.Minimal)]
internal sealed class SingletonSerializationHelper : IObjectReference 
{
    // This object has no fields (although it could).

    // GetRealObject is called after this object is deserialized.
    public Object GetRealObject(StreamingContext context) 
    {
        // When deserialiing this object, return a reference to 
        // the Singleton object instead.
        return Singleton.GetSingleton();
    }
}


class App 
{
    [STAThread]
    static void Main() 
    {
        FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

        try 
        {
            // Construct a BinaryFormatter and use it 
            // to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();

            // Create an array with multiple elements refering to 
            // the one Singleton object.
            Singleton[] a1 = { Singleton.GetSingleton(), Singleton.GetSingleton() };

            // This displays "True".
            Console.WriteLine(
                "Do both array elements refer to the same object? " + 
                (a1[0] == a1[1]));     

            // Serialize the array elements.
            formatter.Serialize(fs, a1);

            // Deserialize the array elements.
            fs.Position = 0;
            Singleton[] a2 = (Singleton[]) formatter.Deserialize(fs);

            // This displays "True".
            Console.WriteLine("Do both array elements refer to the same object? " 
                + (a2[0] == a2[1])); 

            // This displays "True".
            Console.WriteLine("Do all array elements refer to the same object? " 
                + (a1[0] == a2[0]));
        }   
        catch (SerializationException e) 
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }
    }
}
//</snippet1>
