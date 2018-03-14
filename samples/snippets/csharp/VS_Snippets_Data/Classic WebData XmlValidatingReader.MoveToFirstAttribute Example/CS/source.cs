// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {

    //Create the validating reader.
    XmlTextReader txtreader = new XmlTextReader("attrs.xml");
    XmlValidatingReader reader = new XmlValidatingReader(txtreader);

    //Read the genre attribute.
    reader.MoveToContent();
    reader.MoveToFirstAttribute();
    string genre=reader.Value;
    Console.WriteLine("The genre value: " + genre);

    //Close the reader.
    reader.Close();

  } 
} // End class
// </Snippet1>

