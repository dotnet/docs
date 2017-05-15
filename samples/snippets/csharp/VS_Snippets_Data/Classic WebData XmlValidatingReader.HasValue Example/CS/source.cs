// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{

  public static void Main()
  {

    //Create the validating reader.
    XmlTextReader txtreader = new XmlTextReader("book1.xml");
    txtreader.WhitespaceHandling = WhitespaceHandling.None;
    XmlValidatingReader reader = new XmlValidatingReader(txtreader);
    reader.ValidationType = ValidationType.None;

    //Parse the file and each node and its value.
    while (reader.Read())
    {
      if (reader.HasValue)
        Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value);
      else
        Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name);
                 
    }

    //Close the reader.
    reader.Close();
    
  }
} // End class

// </Snippet1>

