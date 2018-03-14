// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Group
{   
   public Employee[] Employees;
}   

// Instruct the XmlSerializer to accept Manager types as well.
[XmlInclude(typeof(Manager))]
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
      test.SerializeObject("IncludeExample.xml");
      test.DeserializeObject("IncludeExample.xml");
   }


   public void SerializeObject(string filename)
   {
      XmlSerializer s = new XmlSerializer(typeof(Group));
      TextWriter writer = new StreamWriter(filename);
      Group group = new Group();
      
      Manager manager = new Manager();
      Employee emp1 = new Employee();
      Employee emp2 = new Employee();

      manager.Name = "Zeus";
      manager.Level = 2;

      emp1.Name = "Ares";

      emp2.Name = "Artemis";

      Employee [] emps = new Employee[3]{manager, emp1, emp2};
      group.Employees = emps;

      s.Serialize(writer, group);
      writer.Close();
   }

   public void DeserializeObject(string filename)
   {
      FileStream fs = new FileStream(filename, FileMode.Open);
      XmlSerializer x = new XmlSerializer(typeof(Group));
      Group g = (Group) x.Deserialize(fs);
      Console.Write("Members:");
      
      foreach(Employee e in g.Employees) 
      {
         Console.WriteLine("\t" + e.Name);
      }
   }
}

// </Snippet1>
