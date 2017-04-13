using System;
using System.Xml;


public class Sample 
{
  public static void Main(){
//<snippet1>

    NameTable nt = new NameTable();
    object book = nt.Add("book");
    object price = nt.Add("price");

    // Create the reader.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.NameTable = nt;
    XmlReader reader = XmlReader.Create("books.xml", settings);

    reader.MoveToContent();
    reader.ReadToDescendant("book");

     if (System.Object.ReferenceEquals(book, reader.Name)) {
         // Do additional processing.
     }

//</snippet1>  
    //Close the reader.
    reader.Close();     
  
  }
} // End class


