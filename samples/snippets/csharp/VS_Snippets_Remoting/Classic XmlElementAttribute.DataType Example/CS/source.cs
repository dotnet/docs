// <Snippet1>
using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class Group
{
   /* Apply two XmlElementAttributes to the field. Set the DataType
      to string an int to allow the ArrayList to accept 
      both types. The Namespace is also set to different values
      for each type. */ 
   [XmlElement(DataType = "string",
   Type = typeof(string),
   Namespace = "http://www.cpandl.com"),
   XmlElement(DataType = "int", 
   Namespace = "http://www.cohowinery.com",
   Type = typeof(int))]
   public ArrayList ExtraInfo;
}

public class Run
{
    public static void Main()
    {
       Run test = new Run();
       test.SerializeObject("ElementTypes.xml");
          }

    public void SerializeObject(string filename)
    {
      // A TextWriter is needed to write the file.
      TextWriter writer = new StreamWriter(filename);

      // Create the XmlSerializer using the XmlAttributeOverrides.
      XmlSerializer s = 
      new XmlSerializer(typeof(Group));

      // Create the object to serialize.
      Group myGroup = new Group();

      /* Add a string and an integer to the ArrayList returned
         by the ExtraInfo field. */
      myGroup.ExtraInfo = new ArrayList();
      myGroup.ExtraInfo.Add("hello");
      myGroup.ExtraInfo.Add(100);

      // Serialize the object and close the TextWriter.
      s.Serialize(writer,myGroup);
      writer.Close();
   }
}

// </Snippet1>
