// System.Web.Services.Discovery.ContractReference.WriteDocument

 /*
The following example demonstrates the 'WriteDocument' method of 
'ContractReference' class. It creates a 'ContactReference' and a 'FileStream' object. 
Then it gets the 'ServiceDescription' object corresponding to the 'test.wsdl' file.
Using the 'WriteDocument' method, the 'ServiceDescription' object is written into the
file stream.
Note: The 'TestInput_cs.wsdl' file should exist in the same folder.
 */

using System;
using System.Web.Services.Discovery;
using System.IO;
using System.Web.Services.Description;

public class DiscoveryDocument_Example
{
    static void Main()
    {
        try
        {
// <Snippet1>
        ContractReference myContractReference = new ContractReference();
        FileStream myFileStream = new FileStream( "TestOutput_cs.wsdl", 
            FileMode.OpenOrCreate, FileAccess.Write );

        // Get the ServiceDescription for the test .wsdl file.
        ServiceDescription myServiceDescription  =
            ServiceDescription.Read("TestInput_cs.wsdl");

        // Write the ServiceDescription into the file stream.
        myContractReference.WriteDocument(myServiceDescription, myFileStream);
        Console.WriteLine("ServiceDescription is written "
            + "into the file stream successfully.");
        Console.WriteLine("The number of bytes written into the file stream: "
            + myFileStream.Length);
         myFileStream.Close();
// </Snippet1>
     }
     catch(Exception e)
     {
        Console.WriteLine("Exception raised:"+e.Message);
     }
   }
  }
