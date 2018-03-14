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

    //Read the ISBN attribute.
    reader.MoveToContent();
    string isbn = reader.GetAttribute("ISBN");
    Console.WriteLine("The ISBN value: " + isbn);

    //Close the reader.
    reader.Close();

  } 
} // End class
// </Snippet1>

