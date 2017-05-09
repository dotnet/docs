//Types:System.Runtime.Serialization.SerializationException Vendor: Richter
//Types:System.Runtime.Serialization.SurrogateSelector Vendor: Richter
//<snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;


// This class is not serializable.
class Employee 
    {
    public String name, address;

    public Employee(String name, String address) 
    {
        this.name = name;
        this.address = address;
    }
}

// This class can manually serialize an Employee object.
sealed class EmployeeSerializationSurrogate : ISerializationSurrogate 
{

    // Serialize the Employee object to save the object’s name and address fields.
    public void GetObjectData(Object obj, 
        SerializationInfo info, StreamingContext context) 
    {

        Employee emp = (Employee) obj;
        info.AddValue("name", emp.name);
        info.AddValue("address", emp.address);
    }

    // Deserialize the Employee object to set the object’s name and address fields.
    public Object SetObjectData(Object obj,
        SerializationInfo info, StreamingContext context,
        ISurrogateSelector selector) 
    {

        Employee emp = (Employee) obj;
        emp.name = info.GetString("name");
        emp.address = info.GetString("address");
        return null;
    }
}

public sealed class App 
{
    static void Main() 
    {
        // This sample uses the BinaryFormatter.
        IFormatter formatter = new BinaryFormatter();

        // Create a MemoryStream that the object will be serialized into and deserialized from.
        using (Stream stream = new MemoryStream()) 
        {
            //<snippet2>
            // Create a SurrogateSelector.
            SurrogateSelector ss = new SurrogateSelector();

            // Tell the SurrogateSelector that Employee objects are serialized and deserialized 
            // using the EmployeeSerializationSurrogate object.
            ss.AddSurrogate(typeof(Employee),
            new StreamingContext(StreamingContextStates.All),
            new EmployeeSerializationSurrogate());
            //</snippet2>

            // Associate the SurrogateSelector with the BinaryFormatter.
            formatter.SurrogateSelector = ss;

            //<snippet3>            
            try 
            {
                // Serialize an Employee object into the memory stream.
                formatter.Serialize(stream, new Employee("Jeff", "1 Microsoft Way"));
            }
            catch (SerializationException e) 
            {
                Console.WriteLine("Serialization failed: {0}", e.Message);
                throw;
            }
            //</snippet3>

            // Rewind the MemoryStream.
            stream.Position = 0;

            try 
            {
                // Deserialize the Employee object from the memory stream.
                Employee emp = (Employee) formatter.Deserialize(stream);

                // Verify that it all worked.
                Console.WriteLine("Name = {0}, Address = {1}", emp.name, emp.address);
            }
            catch (SerializationException e) 
            {
                Console.WriteLine("Deserialization failed: {0}", e.Message);
                throw;
            }
        }
    }
}

// This code produces the following output.
//
// Name = Jeff, Address = 1 Microsoft Way
//</snippet1>