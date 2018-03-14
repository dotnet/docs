// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
    XmlTextReader reader = null;

    try {

       // Load the reader with the XML file.
       reader = new XmlTextReader("book2.xml");
  
       // Parse the file.  If they exist, display the prefix and 
       // namespace URI of each node.
       while (reader.Read()) {
         if (reader.IsStartElement()) {
           if (reader.Prefix==String.Empty)
              Console.WriteLine("<{0}>", reader.LocalName);
           else {
               Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
               Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
           }
         }
       }       

     } 
     finally {
        if (reader != null)
          reader.Close();
      }
  }  
} // End class
   // </Snippet1>

