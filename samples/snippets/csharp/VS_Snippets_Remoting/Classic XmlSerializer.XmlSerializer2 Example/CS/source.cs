using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Class1 {
// <Snippet1>
    private void SerializeObject(string filename) {
        // Create an XmlRootAttribute, and set its properties.
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "CustomRoot";
        xRoot.Namespace = "http://www.cpandl.com";
        xRoot.IsNullable = true;
         
        // Construct the XmlSerializer with the XmlRootAttribute.
        XmlSerializer serializer = new XmlSerializer
            (typeof(OrderedItem),xRoot);
         
        // Create an instance of the object to serialize.
        OrderedItem i = new OrderedItem();
        // Insert code to set properties of the ordered item.
         
        // Writing the document requires a TextWriter.
        TextWriter writer = new StreamWriter(filename);
         
        serializer.Serialize(writer, i);
        writer.Close();
    }

    private void DeserializeObject(string filename) {
        // Create an XmlRootAttribute, and set its properties.
        XmlRootAttribute xRoot = new XmlRootAttribute();
        xRoot.ElementName = "CustomRoot";
        xRoot.Namespace = "http://www.cpandl.com";
        xRoot.IsNullable = true;
         
        XmlSerializer serializer = new XmlSerializer
            (typeof(OrderedItem),xRoot);
         
        // A FileStream is needed to read the XML document.
        FileStream fs = new FileStream(filename, FileMode.Open);
        // Deserialize the object.
        OrderedItem i = (OrderedItem) serializer.Deserialize(fs);
        // Insert code to use the object's properties and methods.
    }

// </Snippet1>

    public class OrderedItem {
        // Members of OrderedItem go here
    }
}
