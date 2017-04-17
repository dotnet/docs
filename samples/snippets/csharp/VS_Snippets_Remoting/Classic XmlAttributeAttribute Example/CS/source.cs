// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

public class Group
{
   [XmlAttribute (Namespace = "http://www.cpandl.com")]
   public string GroupName;
   
   [XmlAttribute(DataType = "base64Binary")]
   public Byte [] GroupNumber;

   [XmlAttribute(DataType = "date", AttributeName = "CreationDate")]
   public DateTime Today;
}


 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("Attributes.xml");
   }


   public void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer =  
      new XmlSerializer(typeof(Group));

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // Set the object properties.
      myGroup.GroupName = ".NET";

      Byte [] hexByte = new Byte[2]{Convert.ToByte(100),
      Convert.ToByte(50)};
      myGroup.GroupNumber = hexByte;

      DateTime myDate = new DateTime(2001,1,10);
      myGroup.Today = myDate;

      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup);
       writer.Close();
   }
}
   
// </Snippet1>
