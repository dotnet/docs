using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class XClass
{
   /* Apply the XmlAnyElementAttribute to a field returning an array
   of XmlElement objects. */
   [XmlAnyElement]
   public XmlElement[] AllElements;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.DeserializeObject("XFile.xml");
   }

   private void DeserializeObject(string filename)
   {
      // Create an XmlSerializer.
      XmlSerializer mySerializer = new XmlSerializer(typeof(XClass));

      // To read a file, a FileStream is needed.
      FileStream fs = new FileStream(filename, FileMode.Open);

      // Deserialize the class.
      XClass x = (XClass) mySerializer.Deserialize(fs);

      // Read the element names and values.
      foreach(XmlElement xel in x.AllElements)
         Console.WriteLine(xel.LocalName + ": " + xel.Value);
   }
}
// </Snippet1>

