// <snippet20>
using System;
using System.IO;
using System.Xml.Serialization;

public class Reader {

  public static void Main() {
    XmlSerializer serializer = new XmlSerializer(typeof(Person));
    FileStream file = new FileStream("test.xml", FileMode.Open);
    Person aPerson = (Person) serializer.Deserialize(file);
    Console.WriteLine(aPerson);
  }

}
// </snippet20>
