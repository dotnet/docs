// System.Web.Services.Discovery.DiscoveryDocumentReference
// System.Web.Services.Discovery.DiscoveryDocumentReference.DiscoveryDocumentReference()
// System.Web.Services.Discovery.DiscoveryDocumentReference.WriteDocument(object, Stream)

/*
   This program demonstrates the 'DiscoveryDocumentReference' class, default constructor and
   'WriteDocument(object, Stream)' method of the 'DiscoveryDocumentReference' class. 
   Discovery file is read by using 'DiscoveryDocument' instance. Write this discovery 
   document into a file stream and print its contents on the console.
*/

// <Snippet1>
using System;
using System.Xml;
using System.Web.Services.Discovery;
using System.IO;
using System.Collections;

public class DiscoveryDocumentReference_ctor_WriteDocument
{
    public static void Main()
    {
        try
        {
            DiscoveryDocument myDiscoveryDocument;
            XmlTextReader myXmlTextReader = 
                new XmlTextReader("http://localhost/Sample_cs.vsdisco");
            myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader);

            // <Snippet2>
            // Create a new instance of DiscoveryDocumentReference.
            DiscoveryDocumentReference myDiscoveryDocumentReference = 
                new DiscoveryDocumentReference();
            // </Snippet2>
            // <Snippet3>
            FileStream myFileStream = new FileStream("Temp.vsdisco", 
                FileMode.OpenOrCreate, FileAccess.Write);
            myDiscoveryDocumentReference.WriteDocument(
                myDiscoveryDocument, myFileStream);
            myFileStream.Close();
            // </Snippet3>

            FileStream myFileStream1 = new FileStream("Temp.vsdisco", 
                FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader myStreamReader = new StreamReader(myFileStream1);

            // Initialize the file pointer.
            myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine("The contents of the discovery document are: \n");
            while(myStreamReader.Peek() > -1)
            {
                // Display the contents of the discovery document.
                Console.WriteLine(myStreamReader.ReadLine());
            }
            myStreamReader.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// </Snippet1>
