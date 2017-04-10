// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class Group
{
   public string GroupName;
   [XmlAttribute]
   public int GroupCode;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.SerializeObject("OverrideRoot.xml");
   }

   // Return an XmlSerializer for overriding attributes.
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributes and XmlAttributeOverrides objects.
      XmlAttributes attrs = new XmlAttributes();
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
   
      XmlRootAttribute xRoot = new XmlRootAttribute();

      // Set a new Namespace and ElementName for the root element.
      xRoot.Namespace = "http://www.cpandl.com";
      xRoot.ElementName = "NewGroup";
      attrs.XmlRoot = xRoot;

      /* Add the XmlAttributes object to the XmlAttributeOverrides. 
         No  member name is needed because the whole class is 
         overridden. */
      xOver.Add(typeof(Group), attrs);

      // Get the XmlAttributes object, based on the type.
      XmlAttributes tempAttrs;
      tempAttrs = xOver[typeof(Group)];

      // Print the Namespace and ElementName of the root.
      Console.WriteLine(tempAttrs.XmlRoot.Namespace);
      Console.WriteLine(tempAttrs.XmlRoot.ElementName);

      XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
      return xSer;
   }

   public void SerializeObject(string filename)
   {
      // Create the XmlSerializer using the CreateOverrider method.
      XmlSerializer xSer = CreateOverrider();

      // Create the object to serialize.
      Group myGroup = new Group();
      myGroup.GroupName = ".NET";
      myGroup.GroupCode = 123;

      // To write the file, a TextWriter is required.
      TextWriter writer = new StreamWriter(filename);

      // Serialize the object and close the TextWriter.
      xSer.Serialize(writer, myGroup);
      writer.Close();
   }
}

// </Snippet1>
