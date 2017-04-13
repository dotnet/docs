// System.web.Services.Discovery.DiscoveryClientProtocol.Download(string,string)
/*
The following example demonstrates the usage of the 'Download' method
of the class 'DiscoveryClientProtocol'. The input to the program is
a discovery file 'MathService_cs.vsdisco'. It generates a 'Stream' 
instance of the discovery file 'MathService_cs.vsdisco' from the 
'Download' method of 'DiscoveryClientPrototocol' and prints out 
the 'contentType' and length in bytes of the discoverydocument.
*/

using System;
using System.Web.Services.Discovery;
using System.Collections;
using System.IO;

public class DiscoveryClientProtocol_Download
{
   public static void Main()
   {
// <Snippet1>
      string myDiscoFile = "http://localhost/MathService_cs.vsdisco";
      string myEncoding = "";
      DiscoveryClientProtocol myDiscoveryClientProtocol = 
            new DiscoveryClientProtocol();

      Stream myStream = myDiscoveryClientProtocol.Download
            (ref myDiscoFile,ref myEncoding);
      Console.WriteLine("The length of the stream in bytes: "+
            myStream.Length);
      Console.WriteLine("The MIME encoding of the downloaded "+
            "discovery document: "+ myEncoding);
      myStream.Close();
// </Snippet1>
   }
}