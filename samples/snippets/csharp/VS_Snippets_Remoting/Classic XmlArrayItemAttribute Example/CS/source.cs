// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Group
{  
   /* The XmlArrayItemAttribute allows the XmlSerializer to insert
      both the base type (Employee) and derived type (Manager) 
      into serialized arrays. */

   [XmlArrayItem(typeof(Manager)),
   XmlArrayItem(typeof(Employee))]
   public Employee[] Employees;

   /* Use the XmlArrayItemAttribute to specify types allowed
      in an array of Object items. */
   [XmlArray]
   [XmlArrayItem (typeof(int),
   ElementName = "MyNumber"),
   XmlArrayItem (typeof(string),
   ElementName = "MyString"),
   XmlArrayItem(typeof(Manager))]
   public object [] ExtraInfo;
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
      test.SerializeObject("TypeDoc.xml");
      test.DeserializeObject("TypeDoc.xml");
   }


   public void SerializeObject(string filename)
   {
      // Creates a new XmlSerializer.
      XmlSerializer s = new XmlSerializer(typeof(Group));

      // Writing the XML file to disk requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);
      Group group = new Group();
      
      Manager manager = new Manager();
      Employee emp1 = new Employee();
      Employee emp2 = new Employee();
      manager.Name = "Consuela";
      manager.Level = 3;
      emp1.Name = "Seiko";
      emp2.Name = "Martina";
      Employee [] emps = new Employee[3]{manager, emp1, emp2};
      group.Employees = emps;

      // Creates an int and a string and assigns to ExtraInfo.
      group.ExtraInfo = new Object[3]{43, "Extra", manager};

      // Serializes the object, and closes the StreamWriter.
      s.Serialize(writer, group);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      FileStream fs = new FileStream(filename, FileMode.Open);
      XmlSerializer x = new XmlSerializer(typeof(Group));
      Group g = (Group) x.Deserialize(fs);
      Console.WriteLine("Members:");
      
      foreach(Employee e in g.Employees) 
      {
         Console.WriteLine("\t" + e.Name);
      }
   }
}
   
// </Snippet1>
