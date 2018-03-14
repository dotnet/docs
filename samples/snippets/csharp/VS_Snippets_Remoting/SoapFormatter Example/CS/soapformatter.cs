//<snippet1>
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;

// Note: When building this code, you must reference the
// System.Runtime.Serialization.Formatters.Soap.dll assembly.
using System.Runtime.Serialization.Formatters.Soap;


class App 
{
    [STAThread]
    static void Main() 
    {
        Serialize();
        Deserialize();
    }

    static void Serialize() 
    {
        // Create a hashtable of values that will eventually be serialized.
        Hashtable addresses = new Hashtable();
        addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
        addresses.Add("Fred", "987 Pine Road, Phila., PA 19116");
        addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301");

        // To serialize the hashtable (and its key/value pairs), 
        // you must first open a stream for writing.
        // Use a file stream here.
        FileStream fs = new FileStream("DataFile.soap", FileMode.Create);

        // Construct a SoapFormatter and use it 
        // to serialize the data to the stream.
        SoapFormatter formatter = new SoapFormatter();
        try 
        {
            formatter.Serialize(fs, addresses);
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

   
    static void Deserialize() 
    {
        // Declare the hashtable reference.
        Hashtable addresses  = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream("DataFile.soap", FileMode.Open);
        try 
        {
            SoapFormatter formatter = new SoapFormatter();

            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            addresses = (Hashtable) formatter.Deserialize(fs);
        }
        catch (SerializationException e) 
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }

        // To prove that the table deserialized correctly, 
        // display the key/value pairs to the console.
        foreach (DictionaryEntry de in addresses) 
        {
            Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
        }
    }
}
//</snippet1>
