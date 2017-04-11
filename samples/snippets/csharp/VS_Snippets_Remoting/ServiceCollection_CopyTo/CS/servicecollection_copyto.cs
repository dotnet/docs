// System.Web.Services.Description.ServiceCollection.Contains(Service)
// System.Web.Services.Description.ServiceCollection.IndexOf(service)
// System.Web.Services.Description.ServiceCollection.CopyTo(System[],int)
/*
   The following program demonstrates the methods of 
   ServiceDescription and ServiceCollection class. An existing WSDL document 
   is read. An exiting service named "MathService" is removed from the 
   collection. A new Service object is constructed and added at index 1 of the 
   Collection .A new WSDL file is created as output.
*/

using System;
using System.Text;
using System.Web.Services.Description;
using System.Collections;
using System.IO;
using System.Xml;

class ServiceDescription_Sample
{
   public static void Main()
   {
      try
      {
         // Read the Existing Wsdl.
         ServiceDescription myServiceDescription= 
                           ServiceDescription.Read("AddSubtractService_CS.wsdl");
        // Remove the service named "MathService".
         ServiceCollection myServiceDescriptionCollection= 
                            myServiceDescription.Services;
         myServiceDescriptionCollection.
                             Remove(myServiceDescription.Services["MathService"]);
         // Build a new Service.
         Service myService =new Service();
         myService.Name="MathService";

         XmlQualifiedName myXmlQualifiedName= 
                        new XmlQualifiedName("s0:MathServiceSoap");
         // Build a new Port for Soap.
         Port mySoapPort= new Port();
         mySoapPort.Name="MathServiceSoap";
         mySoapPort.Binding=myXmlQualifiedName;
         SoapAddressBinding mySoapAddressBinding = 
                                          new SoapAddressBinding();
         mySoapAddressBinding.Location=
                           "http://localhost/ServiceCollection_CopyTo/AddSubtractService_CS.asmx";
         mySoapPort.Extensions.Add(mySoapAddressBinding);

         // Build a new Port for HttpGet.
         XmlQualifiedName myXmlQualifiedName2= 
                           new XmlQualifiedName("s0:MathServiceHttpGet");
         Port myHttpGetPort= new Port();
         myHttpGetPort.Name="MathServiceHttpGet";
         myHttpGetPort.Binding=myXmlQualifiedName2;
         HttpAddressBinding myHttpAddressBinding = 
                            new HttpAddressBinding();
         myHttpAddressBinding.Location=
                         "http://localhost/ServiceCollection_CopyTo/AddSubtractService_CS.asmx";
         myHttpGetPort.Extensions.Add(myHttpAddressBinding);
         // Build a new Port for HttpPost.
         XmlQualifiedName myXmlQualifiedName3=
                        new XmlQualifiedName("s0:MathServiceHttpPost");
         // Build a new Port for Soap.
         Port myHttpPostPort= new Port();
         myHttpPostPort.Name="MathServiceHttpPost";
         myHttpPostPort.Binding=myXmlQualifiedName3;
         HttpAddressBinding myHttpAddressBinding1 =
                              new HttpAddressBinding();
         myHttpAddressBinding1.Location=
                           "http://localhost/ServiceCollection_CopyTo/AddSubtractService_CS.asmx";
         myHttpPostPort.Extensions.Add(myHttpAddressBinding1);

         // Add the ports to the service.
         myService.Ports.Add(mySoapPort);
         myService.Ports.Add(myHttpGetPort);
         myService.Ports.Add(myHttpPostPort);
         // Add the Service to the ServiceCollection.
         myServiceDescription.Services.Insert(1,myService);
         StreamWriter myStreamWriter = new StreamWriter("output.wsdl");
         // Output the Wsdl.
         myServiceDescription.Write(myStreamWriter);
         myStreamWriter.Close();
         
// <Snippet1>
// <Snippet2>
         if(myServiceDescription.Services.Contains(myService))
         {
            Console.WriteLine(
               "The mentioned service exists at index {0} in the WSDL.",
               myServiceDescription.Services.IndexOf(myService));
// <Snippet3>
            Service[] myServiceArray =
               new Service[myServiceDescription.Services.Count];

            // Copy the services into an array.
            myServiceDescription.Services.CopyTo(myServiceArray,0);
            IEnumerator myEnumerator = myServiceArray.GetEnumerator();
            Console.WriteLine("The names of services in the array are");
            while(myEnumerator.MoveNext())
            {
               Service myService1 = (Service)myEnumerator.Current;
               Console.WriteLine(myService1.Name);
            }
// </Snippet3>
         }
         else
         {
            Console.WriteLine("Service does not exist in the WSDL." );
         }
// </Snippet2>
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception Caught! " + e.Message);
      }
   }
}
