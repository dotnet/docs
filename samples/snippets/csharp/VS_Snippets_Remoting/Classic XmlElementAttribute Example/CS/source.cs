// <Snippet1>
using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class Group
{
   /* Set the element name and namespace of the XML element.
   By applying an XmlElementAttribute to an array,  you instruct
   the XmlSerializer to serialize the array as a series of XML
   elements, instead of a nested set of elements. */
   
   [XmlElement(
   ElementName = "Members",
   Namespace = "http://www.cpandl.com")]
   public Employee[] Employees;
      
   [XmlElement(DataType = "double",
   ElementName = "Building")]
   public double GroupID;

   [XmlElement(DataType = "hexBinary")]
   public byte [] HexBytes;


   [XmlElement(DataType = "boolean")]
   public bool IsActive;

   [XmlElement(Type = typeof(Manager))]
   public Employee Manager;

   [XmlElement(typeof(int),
   ElementName = "ObjectNumber"),
   XmlElement(typeof(string),
   ElementName = "ObjectString")]
   public ArrayList ExtraInfo;
}   

public class Employee
{
   public string Name;
}

public class Manager:Employee{
   public int Level;
}

public class Run
{
    public static void Main()
    {
       Run test = new Run();
       test.SerializeObject("FirstDoc.xml");
       test.DeserializeObject("FirstDoc.xml");
    }


   public void SerializeObject(string filename)
   {
      // Create the XmlSerializer.
      XmlSerializer s = new XmlSerializer(typeof(Group));

      // To write the file, a TextWriter is required.
      TextWriter writer = new StreamWriter(filename);

      /* Create an instance of the group to serialize, and set
         its properties. */
      Group group = new Group();
      group.GroupID = 10.089f;
      group.IsActive = false;
      
      group.HexBytes = new byte[1]{Convert.ToByte(100)};

      Employee x = new Employee();
      Employee y = new Employee();

      x.Name = "Jack";
      y.Name = "Jill";
      
      group.Employees = new Employee[2]{x,y};

      Manager mgr = new Manager();
      mgr.Name = "Sara";
      mgr.Level = 4;
      group.Manager = mgr;

      /* Add a number and a string to the 
      ArrayList returned by the ExtraInfo property. */
      group.ExtraInfo = new ArrayList();
      group.ExtraInfo.Add(42);
      group.ExtraInfo.Add("Answer");

      // Serialize the object, and close the TextWriter.      
      s.Serialize(writer, group);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      FileStream fs = new FileStream(filename, FileMode.Open);
      XmlSerializer x = new XmlSerializer(typeof(Group));
      Group g = (Group) x.Deserialize(fs);
      Console.WriteLine(g.Manager.Name);
      Console.WriteLine(g.GroupID);
      Console.WriteLine(g.HexBytes[0]);
      foreach(Employee e in g.Employees)
      {
         Console.WriteLine(e.Name);
      }
   }
}
   
// </Snippet1>


