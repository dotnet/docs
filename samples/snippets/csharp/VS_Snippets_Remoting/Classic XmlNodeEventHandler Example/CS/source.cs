using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Class1 {
// <Snippet1>

    private void DeserializeItem(string filename) {
        XmlSerializer mySerializer = 
            new XmlSerializer(typeof(ObjectToDeserialize));
        // Add an instance of the delegate to the event.
        mySerializer.UnknownNode += new XmlNodeEventHandler
            (Serializer_UnknownNode);
        // A FileStream is needed to read the file to deserialize.
        FileStream fs = new FileStream(filename, FileMode.Open);
        ObjectToDeserialize o = (ObjectToDeserialize)mySerializer.Deserialize(fs);
    }
     
    private void Serializer_UnknownNode
        (object sender, XmlNodeEventArgs e) {
        
        Console.WriteLine("UnknownNode Name: "
                          + e.Name);
        Console.WriteLine("UnknownNode LocalName: "
                          + e.LocalName);
        Console.WriteLine("UnknownNode Namespace URI: "
                          + e.NamespaceURI);
        Console.WriteLine("UnknownNode Text: "
                          + e.Text);
     
        object o = e.ObjectBeingDeserialized;
        Console.WriteLine("Object being deserialized " 
                          + o.ToString());
           
        XmlNodeType myNodeType = e.NodeType;
        Console.WriteLine(myNodeType);
    }

// </Snippet1>

    public class ObjectToDeserialize {
        // Class added so that sample will compile
    }
}
