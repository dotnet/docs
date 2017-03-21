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

            // Create a new instance of DiscoveryDocumentReference.
            DiscoveryDocumentReference myDiscoveryDocumentReference = 
                new DiscoveryDocumentReference();
            FileStream myFileStream = new FileStream("Temp.vsdisco", 
                FileMode.OpenOrCreate, FileAccess.Write);
            myDiscoveryDocumentReference.WriteDocument(
                myDiscoveryDocument, myFileStream);
            myFileStream.Close();

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