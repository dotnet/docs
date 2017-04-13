//<snippet1>
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

// This class is serializable and will have its OnDeserialization method
// called after each instance of this class is deserialized.
[Serializable]
class Circle : IDeserializationCallback 
{
    Double m_radius;

    // To reduce the size of the serialization stream, the field below is 
    // not serialized. This field is calculated when an object is constructed
    // or after an instance of this class is deserialized.
    [NonSerialized] public Double m_area;

    public Circle(Double radius) 
    {
        m_radius = radius;
        m_area = Math.PI * radius * radius;
    }

    void IDeserializationCallback.OnDeserialization(Object sender) 
    {
        // After being deserialized, initialize the m_area field 
        // using the deserialized m_radius value.
        m_area = Math.PI * m_radius * m_radius;
    }

    public override String ToString() 
    {
        return String.Format("radius={0}, area={1}", m_radius, m_area);
    }
}


class Class1 
{
    [STAThread]
    static void Main(string[] args) 
    {
        Serialize();
        Deserialize();
    }

    static void Serialize() 
    {
        Circle c = new Circle(10);
        Console.WriteLine("Object being serialized: " + c.ToString());

        // To serialize the Circle, you must first open a stream for 
        // writing. Use a file stream here.
        FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

        // Construct a BinaryFormatter and use it 
        // to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
        try 
        {
            formatter.Serialize(fs, c);
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
        // Declare the Circle reference.
        Circle c = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the Circle from the file and 
            // assign the reference to the local variable.
            c = (Circle) formatter.Deserialize(fs);
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

        // To prove that the Circle deserialized correctly, display its area.
        Console.WriteLine("Object being deserialized: " + c.ToString());
    }
}
//</snippet1>