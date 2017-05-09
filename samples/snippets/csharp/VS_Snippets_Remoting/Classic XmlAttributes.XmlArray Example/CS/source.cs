// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Group
{
   // This field will be overridden.
   public Member [] Members;
}

public class Member
{
   public string MemberName;
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("OverrideArray.xml");
      test.DeserializeObject("OverrideArray.xml");
   }
   // Return an XmlSerializer used for overriding. 
   public XmlSerializer CreateOverrider()
   {
      // Creating XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      XmlAttributes xAttrs = new XmlAttributes();

      // Add an override for the XmlArray.    
      XmlArrayAttribute xArray = new XmlArrayAttribute("Staff");
      xArray.Namespace = "http://www.cpandl.com";
      xAttrs.XmlArray = xArray;
      xOver.Add(typeof(Group), "Members", xAttrs);

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

      // Set the object properties.
      Member m = new Member();
      m.MemberName = "Paul";
      myGroup.Members = new Member[1] {m};
      
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
      foreach(Member m in myGroup.Members)
      {
         Console.WriteLine(m.MemberName);
      }
   }
}
   
// </Snippet1>
