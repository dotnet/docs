// <Snippet1>
using System;
using System.Xml; 

public class Sample {

  private static string filename = "tworeads.xml";
   
  public static void Main() {
  
    XmlTextReader reader = new XmlTextReader(filename);
    reader.WhitespaceHandling=WhitespaceHandling.None;

    // Read the first part of the XML document
    while(reader.Read()) {
      // Display the elements and stop reading on the book endelement tag
      // then go to ReadPart2 to start another reader to read the rest of the file. 
      switch(reader.NodeType) {
       case XmlNodeType.Element:
        Console.WriteLine("Name: {0}", reader.Name);
        break;
       case XmlNodeType.Text:
        Console.WriteLine("  Element Text: {0}", reader.Value);
        break;
       case XmlNodeType.EndElement:
        // Stop reading when the reader gets to the end element of the book node.
        if ("book"==reader.LocalName) {
          Console.WriteLine("End reading first book...");
          Console.WriteLine();      
          goto ReadPart2;
        }
        break;
      } 
    } 

    // Read the rest of the XML document
    ReadPart2:
    Console.WriteLine("Begin reading second book...");

    // Create a new reader to read the rest of the document.
    XmlTextReader reader2 = new XmlTextReader(reader.GetRemainder());

    while(reader2.Read()) {
      switch (reader2.NodeType) {
        case XmlNodeType.Element:
         Console.WriteLine("Name: {0}", reader2.Name);
         break;
        case XmlNodeType.Text:
         Console.WriteLine("  Element Text: {0}", reader2.Value);
         break;
        case XmlNodeType.EndElement:
         // Stop reading when the reader gets to the end element of the book node.
         if ("book"==reader2.LocalName) {
           Console.WriteLine("End reading second book...");
           goto Done;
         }
         break;
      }
    }

    Done:
    Console.WriteLine("Done.");
    reader.Close(); 
    reader2.Close();
  }
}//End class
   // </Snippet1>

