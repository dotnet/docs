// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Group
{
   /* The Type property instructs the XmlSerializer to accept both
   the Person and Manager types in the array. */
   [XmlArrayItem(Type = typeof(Manager)),
   XmlArrayItem(Type=typeof(Person))]
   public Person[]Staff;
}

public class Person
{
   public string Name;
}

public class Manager:Person
{
   public int Rank;
}

public class Run 
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOrder("TypeEx.xml");
   }


   public void SerializeOrder(string filename)
   {
      // Creates an XmlSerializer.
      XmlSerializer xSer = 
      new XmlSerializer(typeof(Group));

      // Creates the Group object, and two array items.
      Group myGroup = new Group();

      Person p1 = new Person();
      p1.Name = "Jacki";
      Manager p2 = new Manager();

      p2.Name = "Megan";
      p2.Rank = 2;

      Person [] myStaff = {p1,p2};
      myGroup.Staff = myStaff;

      // Serializes the object, and closes the StreamWriter.
      TextWriter writer = new StreamWriter(filename);
      xSer.Serialize(writer, myGroup);
   }
}
// </Snippet1>
