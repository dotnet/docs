// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that is the default root element.
public class MyClass
{
   public string Name;
}

public class Run 
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOrder("OverrideAttribute.xml");
   }

   public void SerializeOrder(string filename)
   {
      // Create an XmlSerializer instance using the method below.
      XmlSerializer xSer = CreateOverrider();

      // Create the object, and set its Name property.
      MyClass myClass = new MyClass();
      myClass.Name = "New Class Name";

      // Serialize the class, and close the TextWriter.
      TextWriter writer = new StreamWriter(filename);
      xSer.Serialize(writer, myClass);
      writer.Close();
   }

   // Return an XmlSerializer to override the root serialization.
   public XmlSerializer CreateOverrider()
   {
      // Create an XmlAttributes to override the default root element.
      XmlAttributes attrs = new XmlAttributes();

      // Create an XmlRootAttribute and set its element name and namespace.
      XmlRootAttribute xRoot = new XmlRootAttribute();
      xRoot.ElementName = "OverriddenRootElementName";
      xRoot.Namespace = "http://www.microsoft.com";

      // Set the XmlRoot property to the XmlRoot object.
      attrs.XmlRoot = xRoot;
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      
      /* Add the XmlAttributes object to the 
      XmlAttributeOverrides object. */
      xOver.Add(typeof(MyClass), attrs);

      // Create the Serializer, and return it.
      XmlSerializer xSer = new XmlSerializer
      (typeof(MyClass), xOver);
      return xSer;
   }
}

// </Snippet1>
