using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {

//<snippet1>

      // Add the element names to the NameTable.
      NameTable nt = new NameTable();
      object book = nt.Add("book");
      object title = nt.Add("title");

       // Create a reader that uses the NameTable.
       XmlReaderSettings settings = new XmlReaderSettings();
       settings.NameTable = nt;
       XmlReader reader = XmlReader.Create("books.xml", settings);

       while (reader.Read()) {
          if (reader.NodeType == XmlNodeType.Element) {
            // Cache the local name to prevent multiple calls to the LocalName property.
            object localname = reader.LocalName;

            // Do a comparison between the object references. This just compares pointers.
            if (book == localname) {
                // Add additional processing here.
            }
            // Do a comparison between the object references. This just compares pointers.
            if (title == localname) {
               // Add additional processing here.
            }
               
          } 

       }  // End While

      // Close the reader.
      reader.Close();     

  //</snippet1>
  
  }
} 

