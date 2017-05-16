//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main(){

    //Create the reader.
    XmlTextReader txtreader = new XmlTextReader("book4.xml");
    XmlValidatingReader reader = new XmlValidatingReader(txtreader);

    reader.MoveToContent();

    //Display each of the attribute nodes, including default attributes.
    while (reader.MoveToNextAttribute()){
        if (reader.IsDefault)
          Console.Write("(default attribute) ");
        Console.WriteLine("{0} = {1}", reader.Name, reader.Value);  
    }           
  
    //Close the reader.
    reader.Close();     
  
  }
} // End class
//</snippet1>


