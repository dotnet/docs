using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Class1 {

// <Snippet1>
    private void SerializeObject(string filename) {
        XmlSerializer serializer = new XmlSerializer
            (typeof(OrderedItem), "http://www.cpandl.com");
         
        // Create an instance of the class to be serialized.
        OrderedItem i = new OrderedItem();
         
        // Insert code to set property values.
         
        // Writing the document requires a TextWriter.
        TextWriter writer = new StreamWriter(filename);
        // Serialize the object, and close the TextWriter
        serializer.Serialize(writer, i);
        writer.Close();
    }
 
    private void DeserializeObject(string filename) {
        XmlSerializer serializer = new XmlSerializer
            (typeof(OrderedItem), "http://www.cpandl.com");
        // A FileStream is needed to read the XML document.
        FileStream fs = new FileStream(filename, FileMode.Open);
         
        // Declare an object variable of the type to be deserialized.
        OrderedItem i;
         
        // Deserialize the object.
        i = (OrderedItem) serializer.Deserialize(fs);
         
        // Insert code to use the properties and methods of the object.
    }

// </Snippet1>

    public class OrderedItem {
        // Members of OrderedItem go here
    }
}
