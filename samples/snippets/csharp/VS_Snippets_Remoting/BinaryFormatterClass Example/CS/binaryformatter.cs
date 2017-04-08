//<snippet1>
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class App 
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

        // To serialize the hashtable and its key/value pairs,  
        // you must first open a stream for writing. 
        // In this case, use a file stream.
        FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

        // Construct a BinaryFormatter and use it to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
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
        FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();

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
        // display the key/value pairs.
        foreach (DictionaryEntry de in addresses) 
        {
            Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
        }
    }
}
//</snippet1>