// System.Web.Services.Discovery.ContractReference.ReadDocument
/* 
 * The following example demonstrates the 'ReadDocument' method of the 
 * 'ContractReference' class.
 * It creates an instance of 'ContractReference' class and calls the 
 * 'ReadDocument' method passing a service description stream and get a 
 * 'ServiceDescription' instance.
 */

using System;
using System.IO;
using System.Web.Services.Discovery;
using System.Web.Services.Description;

namespace ConsoleApplication1
{
// <Snippet1>
   class MyClass1
   {
      static void Main()
      {
         try
         {
            // Create the file stream.
            FileStream wsdlStream = new FileStream("MyService1_cs.wsdl",
                FileMode.Open);
            ContractReference myContractReference=new ContractReference();

            // Read the service description from the passed stream.
            ServiceDescription myServiceDescription=
                (ServiceDescription)myContractReference.ReadDocument(wsdlStream);
            Console.Write("Target Namespace for the service description is: "
                + myServiceDescription.TargetNamespace);
            wsdlStream.Close();
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception: "+e.Message);
         }
      }
   }
// </Snippet1>
}
