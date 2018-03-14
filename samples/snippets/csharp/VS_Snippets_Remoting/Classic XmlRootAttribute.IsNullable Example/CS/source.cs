// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

// Apply the XmlRootAttribute and set the IsNullable property to false.
[XmlRoot(IsNullable = false)]
public class Group
{   
   public string Name;
}   


public class Run
{
   public static void Main()
   {
   Console.WriteLine("Running");
      Run test = new Run();
      test.SerializeObject("NullDoc.xml");

   }

   public void SerializeObject(string filename)
   {
      XmlSerializer s = new XmlSerializer(typeof(Group));

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create the object to serialize.
      Group mygroup = null;
      
      // Serialize the object, and close the TextWriter.
      s.Serialize(writer, mygroup);
      writer.Close();
   }
}
   
// </Snippet1>
