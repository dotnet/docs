// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Group
{   
   [XmlArray(IsNullable = true)]
   [XmlArrayItem(typeof(Manager), IsNullable = false),
   XmlArrayItem(typeof(Employee), IsNullable = false)]
   public Employee[] Employees;
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
      test.SerializeObject("TypeDoc.xml");
   }

   public void SerializeObject(string filename)
   {
      XmlSerializer s = new XmlSerializer(typeof(Group));

      // To write the file, a TextWriter is required.
      TextWriter writer = new StreamWriter(filename);

      // Creates the object to serialize.
      Group group = new Group();

      // Creates a null Manager object.
      Manager mgr = null;
      
      // Creates a null Employee object.
      Employee y = null;
      
      group.Employees = new Employee[2] {mgr, y};

      // Serializes the object and closes the TextWriter.
      s.Serialize(writer, group);
      writer.Close();

   }
}

// </Snippet1>
