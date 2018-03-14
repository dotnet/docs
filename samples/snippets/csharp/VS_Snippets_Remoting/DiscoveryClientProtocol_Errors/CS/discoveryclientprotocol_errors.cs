// System.web.Services.Discovery.DiscoveryClientProtocol.Errors
/*
   The following example demonstrates the usage of the 'Errors' property
   of the class 'DiscoveryClientProtocol'. The input to the program is
   a discovery file 'MathService_cs.vsdisco', which holds reference 
   related to 'MathService_cs.asmx' web service. The program is 
   excecuted first time with existence of the file 
   'MathService_cs.asmx' in the location as specified in the discovery
   file. The file 'MathService_cs.asmx' is removed from the referred 
   location in a way to simulate a scenario wherein the file related 
   to web service is missing, and the program is excecuted the second time
   to show the exception occuring.
*/

using System;
using System.Web.Services.Discovery;
using System.Collections;

public class DiscoveryClientProtocol_Errors
{
   public static void Main()
   {
// <Snippet1>
      string myDiscoFile = "http://localhost/MathService_cs.vsdisco";
      string myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
      DiscoveryClientProtocol myDiscoveryClientProtocol = 
            new DiscoveryClientProtocol();

      // Get the discovery document.
      DiscoveryDocument myDiscoveryDocument = 
         myDiscoveryClientProtocol.Discover(myDiscoFile);
      IEnumerator myEnumerator = 
            myDiscoveryDocument.References.GetEnumerator();
      while ( myEnumerator.MoveNext() )
      {
         ContractReference myContractReference =
            (ContractReference)myEnumerator.Current;

         // Get the DiscoveryClientProtocol from the ContractReference.
         myDiscoveryClientProtocol = myContractReference.ClientProtocol;
         myDiscoveryClientProtocol.ResolveAll();

         DiscoveryExceptionDictionary myExceptionDictionary 
            = myDiscoveryClientProtocol.Errors;

         if (myExceptionDictionary.Contains(myUrlKey))
         {
            Console.WriteLine("System generated exceptions.");

            // Get the exception from the DiscoveryExceptionDictionary.
            Exception myException = myExceptionDictionary[myUrlKey];

            Console.WriteLine(" Source : " + myException.Source);
            Console.WriteLine(" Exception : " + myException.Message);
         }
      }
// </Snippet1>
   }
}