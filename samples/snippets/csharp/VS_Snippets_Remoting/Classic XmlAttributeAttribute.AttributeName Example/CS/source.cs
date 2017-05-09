// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class Group
{
   // Change the XML attribute name.
   [XmlAttribute(AttributeName = "MgrName")]
   public string Name;
   /* Use the AttributeName to collect all the XML attributes
   in the XML-document instance. */
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      /* To use the AttributeName to collect all the
      XML attributes. Call SerializeObject to generate 
      an XML document and alter the document by adding
      new XML attributes to it. Then comment out the SerializeObject
      method, and call DeserializeObject. */
      test.SerializeObject("MyAtts.xml");
      test.DeserializeObject("MyAtts.xml");
}
public void SerializeObject(string filename)
{
   Console.WriteLine("Serializing");
   // Create an instance of the XmlSerializer class.
   XmlSerializer mySerializer =  new XmlSerializer(typeof(Group));
   // Writing the file requires a TextWriter.
   TextWriter writer = new StreamWriter(filename);
   // Create an instance of the class that will be serialized.
   Group myGroup = new Group();
   /* Set the Name property, which will be generated
   as an XML attribute. */
   myGroup.Name = "Wallace";
   // Serialize the class, and close the TextWriter.
   mySerializer.Serialize(writer, myGroup);
   writer.Close();
}

   public void DeserializeObject(string filename)
   {
      Console.WriteLine("Deserializing");
      XmlSerializer mySerializer =
      new XmlSerializer(typeof(Group));
      FileStream fs = new FileStream(filename, FileMode.Open);
      Group myGroup = (Group)
      mySerializer.Deserialize(fs);
      Console.WriteLine(myGroup.Name);
   }
}
   
// </Snippet1>
