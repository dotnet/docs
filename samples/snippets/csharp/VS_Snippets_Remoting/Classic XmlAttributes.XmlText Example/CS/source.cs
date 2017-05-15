// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Group
{
   public string GroupName;

   // This field will be serialized as XML text. 
   public string Comment;
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("OverrideText.xml");
      test.DeserializeObject("OverrideText.xml");
   }

   // Return an XmlSerializer to be used for overriding. 
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      XmlAttributes xAttrs = new XmlAttributes();

      /* Create an XmlTextAttribute and assign it to the XmlText 
      property. This instructs the XmlSerializer to treat the 
      Comment field as XML text. */      
      XmlTextAttribute xText = new XmlTextAttribute();
      xAttrs.XmlText = xText;
      xOver.Add(typeof(Group), "Comment", xAttrs);

      // Create the XmlSerializer, and return it.
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

      // Set the object properties.
      myGroup.GroupName = ".NET";
      myGroup.Comment = "Great Stuff!";      
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
      Console.WriteLine(myGroup.Comment);
   }
}
   
// </Snippet1>
