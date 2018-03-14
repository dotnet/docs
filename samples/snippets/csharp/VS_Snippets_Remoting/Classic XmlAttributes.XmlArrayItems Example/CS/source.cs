// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Group
{
    public Member [] Members;
}

public class Member
{
    public string MemberName;
}

public class NewMember:Member
{
    public int MemberID;
}

public class RetiredMember:NewMember
{
    public DateTime RetireDate;
}
    

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("OverrideArrayItem.xml");
      test.DeserializeObject("OverrideArrayItem.xml");
   }

   // Return an XmlSerializer used for overriding. 
   public XmlSerializer CreateOverrider()
   {
      // Create XmlAttributeOverrides and XmlAttributes objects.
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      XmlAttributes xAttrs = new XmlAttributes();

      // Add an override for the XmlArrayItem.    
      XmlArrayItemAttribute xArrayItem = 
      new XmlArrayItemAttribute(typeof(NewMember));
      xArrayItem.Namespace = "http://www.cpandl.com";
      xAttrs.XmlArrayItems.Add(xArrayItem);

      // Add a second override.
      XmlArrayItemAttribute xArrayItem2 = 
      new XmlArrayItemAttribute(typeof(RetiredMember));
      xArrayItem2.Namespace = "http://www.cpandl.com";
      xAttrs.XmlArrayItems.Add(xArrayItem2);

      // Add all overrides to XmlAttribueOverrides object.
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
      NewMember m = new NewMember();
      m.MemberName = "Paul";
      m.MemberID = 2;

      // Create a second member.
      RetiredMember m2 = new RetiredMember();
      m2.MemberName = "Renaldo";
      m2.MemberID = 23;
      m2.RetireDate = new DateTime(2000, 10,10);

      myGroup.Members = new Member[2] {m, m2};
      
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
