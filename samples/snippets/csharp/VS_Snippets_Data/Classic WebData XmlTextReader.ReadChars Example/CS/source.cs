// <Snippet1>
using System;
using System.Xml;

// Reads an XML document using ReadChars

public class Sample {

  private const String filename = "items.xml";

  public static void Main() {
  
    XmlTextReader reader = null;

    try {
          
      // Declare variables used by ReadChars
      Char []buffer;
      int iCnt = 0;
      int charbuffersize;
     
      // Load the reader with the data file.  Ignore white space.
      reader = new XmlTextReader(filename);
      reader.WhitespaceHandling = WhitespaceHandling.None;

      // Set variables used by ReadChars.
      charbuffersize = 10;
      buffer = new Char[charbuffersize];

      // Parse the file.  Read the element content
      // using the ReadChars method.
      reader.MoveToContent();
      while ( (iCnt = reader.ReadChars(buffer,0,charbuffersize)) > 0 ) {
        // Print out chars read and the buffer contents.
        Console.WriteLine ("  Chars read to buffer:" + iCnt);
        Console.WriteLine ("  Buffer: [{0}]", new String(buffer,0,iCnt));
        // Clear the buffer.
        Array.Clear(buffer,0,charbuffersize);
      }
       
    }
    finally {
      if (reader!=null)
        reader.Close();
    }
  }

} // End class
   // </Snippet1>

