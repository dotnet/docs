// System.Web.Services.Discovery.DiscoveryDocument.Write(XmlTextWriter)

/* The following example deomonstrates the 'Write(XmlTextWriter)' method
   of the 'DiscoveryDocument' class.
   A XmlTextReader object is created with a sample discovery file and this is
   passed to the Read method to create a DiscoveryDocument. The contents of this
   document are displayed onto the console using the Write(XmlTextWriter) method.
*/

using System;
using System.Xml;
using System.IO;
using System.Web.Services.Discovery;
using System.Collections;

public class DiscoveryDocument_Example
{
   static void Main()
   {
      try
      {
// <Snippet1>
         // Create a DiscoveryDocument.
         DiscoveryDocument myDiscoveryDocument = new DiscoveryDocument();

         // Create an XmlTextReader with the sample file.
         XmlTextReader myXmlTextReader = new
            XmlTextReader( "http://localhost/example_Write2_cs.disco" );

         // Read the given XmlTextReader.
         myDiscoveryDocument = DiscoveryDocument.Read( myXmlTextReader );

         FileStream myFileStream = new
            FileStream( "log.txt", FileMode.OpenOrCreate, FileAccess.Write );
         StreamWriter myStreamWriter = new StreamWriter( myFileStream );


         XmlTextWriter myXmlTextWriter = new XmlTextWriter( myStreamWriter );
         myDiscoveryDocument.Write( myXmlTextWriter );


         myXmlTextWriter.Flush();
         myXmlTextWriter.Close();

         // Display the contents of the DiscoveryDocument on the console.
         FileStream myFileStream1 = new
            FileStream( "log.txt", FileMode.OpenOrCreate, FileAccess.Read );
         StreamReader myStreamReader = new StreamReader( myFileStream1 );

         // Set the file pointer to the beginning.
         myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
         Console.WriteLine( "The contents of the DiscoveryDocument are:" );
         while ( myStreamReader.Peek() > -1 )
         {
            Console.WriteLine( myStreamReader.ReadLine() );
         }
         myStreamReader.Close();
// </Snippet1>
   }
      catch( Exception e )
      {
         Console.WriteLine( "Exception raised : {0}", e.Message);
      }
   }
}
