// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Group
{
   // This is the attribute that will be overridden.
   [XmlAttribute]
   public string GroupName;
   public int GroupNumber;
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("OverrideAttribute.xml");
      test.DeserializeObject("OverrideAttribute.xml");
   }
   // Return an XmlSerializer used for overriding. 
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      XmlAttributes xAttrs = new XmlAttributes();

      /* Create an overriding XmlAttributeAttribute set it to 
      the XmlAttribute property of the XmlAttributes object.*/
      XmlAttributeAttribute xAttribute = new XmlAttributeAttribute("SplinterName");
      xAttrs.XmlAttribute = xAttribute;

      // Add to the XmlAttributeOverrides. Specify the member name.
      xOver.Add(typeof(Group), "GroupName", xAttrs);

      // Create the XmlSerializer and return it.
      return new XmlSerializer(typeof(Group), xOver);
   }
 
   public void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer =  CreateOverrider();
      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      /* Set the Name property, which will be generated 
      as an XML attribute. */
      myGroup.GroupName = ".NET";
      myGroup.GroupNumber = 1;
      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup);
       writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      XmlSerializer mySerializer = CreateOverrider();
      FileStream fs = new FileStream(filename, FileMode.Open);
      Group myGroup = (Group) 
      mySerializer.Deserialize(fs);
      
      Console.WriteLine(myGroup.GroupName);
      Console.WriteLine(myGroup.GroupNumber);
   }
}
   
// </Snippet1>
