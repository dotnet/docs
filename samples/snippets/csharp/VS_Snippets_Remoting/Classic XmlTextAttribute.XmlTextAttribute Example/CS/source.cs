// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;


public class Group {
    public string GroupName;
    public string Comment;
}

public class Test {
    public static void Main() {
        Test t = new Test();
        t.SerializerOrder("TextOverride.xml");
    }
    /* Create an instance of the XmlSerializer class that overrides 
       the default way it serializes an object. */
    public XmlSerializer CreateOverrider() {
        /* Create instances of the XmlAttributes and 
        XmlAttributeOverrides classes. */
   
        XmlAttributes attrs = new XmlAttributes();

        XmlAttributeOverrides xOver = new XmlAttributeOverrides();
              
        /* Create an XmlTextAttribute to override the default 
        serialization process. */
        XmlTextAttribute xText = new XmlTextAttribute();
        attrs.XmlText = xText;

        // Add the XmlAttributes to the XmlAttributeOverrides.
        xOver.Add(typeof(Group), "Comment", attrs);

        // Create the XmlSerializer, and return it.
        XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
        return xSer;
    }

    public void SerializerOrder(string filename) {
        // Create an XmlSerializer instance.
        XmlSerializer xSer = CreateOverrider();

        // Create the object and serialize it.
        Group myGroup = new Group();
        myGroup.Comment = "This is a great product.";
      
        TextWriter writer = new StreamWriter(filename);
        xSer.Serialize(writer, myGroup);
    }
}
   
// </Snippet1>
