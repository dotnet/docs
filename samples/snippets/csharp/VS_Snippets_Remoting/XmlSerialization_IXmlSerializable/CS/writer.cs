// <snippet10>
using System;
using System.Xml;
using System.Xml.Serialization;

public class Writer {

  public static void Main() {

    // Create a person object.
    Person fred = new Person("Fred Flintstone");

    // Serialize the object to a file.
    XmlTextWriter writer = new XmlTextWriter("test.xml", null);
    XmlSerializer serializer = new XmlSerializer(typeof(Person));
    serializer.Serialize(writer, fred);
  }

}
// </snippet10>
