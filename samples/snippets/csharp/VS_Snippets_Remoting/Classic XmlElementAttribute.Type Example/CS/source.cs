// <Snippet1>
using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Group
{
   [XmlElement(typeof(Manager))]
   public Employee [] Staff;

   [XmlElement (typeof(int)),
   XmlElement (typeof(string)),
   XmlElement (typeof(DateTime))]
   public ArrayList ExtraInfo;
}

public class Employee
{
   public string Name;
}

public class Manager:Employee
{
   public int Level;
}

public class Run 
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("TypeEx.xml");
   }

   public void SerializeObject(string filename)
   {
      // Create an XmlSerializer instance.
      XmlSerializer xSer = 
      new XmlSerializer(typeof(Group));

      // Create object and serialize it.
      Group myGroup = new Group();
      
      Manager e1 = new Manager();
      e1.Name = "Manager1";
      Manager m1 =  new Manager();
      m1.Name = "Manager2";
      m1.Level = 4;

      Employee[] emps = {e1, m1};
      myGroup.Staff = emps;

      myGroup.ExtraInfo = new ArrayList();
      myGroup.ExtraInfo.Add(".NET");
      myGroup.ExtraInfo.Add(42);
      myGroup.ExtraInfo.Add(new DateTime(2001,1,1));
      
      TextWriter writer = new StreamWriter(filename);
      xSer.Serialize(writer, myGroup);
      writer.Close();
   }
}

// </Snippet1>
