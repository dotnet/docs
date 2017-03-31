// System.Web.Services.Discovery.DiscoveryClientProtocol.AdditionalInformation

/* The following example demonstrates 'AdditionalInformation' of DiscoveryClientProtocol
   class.
   In the example 'SoapBinding' informations is added to a 'DiscoveryClientProtocol' using
   'AdditionalInformation' collection. The soap binding added is retrived back and SoapBinding
   address is displayed. The resultant document is written back.
*/


// <Snippet1>
using System;
using System.Net;
using System.Security.Permissions;
using System.Xml;
using System.Web.Services.Discovery;

class DiscoverySoapBindingClass
{
   static void Main()
   {
      Run();
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   static void Run()
   {
        try
        {

            // dataservice.disco is a sample discovery document.
            string myStringUrl = "http://localhost/dataservice.disco";

            // Call the Discover method to populate the Documents property.
            DiscoveryClientProtocol myDiscoveryClientProtocol = 
                new DiscoveryClientProtocol();
            myDiscoveryClientProtocol.Credentials = 
                CredentialCache.DefaultCredentials;
            DiscoveryDocument myDiscoveryDocument = 
                myDiscoveryClientProtocol.Discover(myStringUrl);

            SoapBinding mySoapBinding = new SoapBinding();
            mySoapBinding.Address = "http://schemas.xmlsoap.org/disco/scl/";
            mySoapBinding.Binding = new XmlQualifiedName("string", 
                "http://www.w3.org/2001/XMLSchema");
            myDiscoveryClientProtocol.AdditionalInformation.Add(mySoapBinding);

            // Write the information back.
            myDiscoveryClientProtocol.WriteAll("MyDirectory",
                "results.discomap");

            System.Collections.IList myIList = 
                myDiscoveryClientProtocol.AdditionalInformation;
            mySoapBinding = null;
            mySoapBinding = (SoapBinding)myIList[0];
            Console.WriteLine("The address of the SoapBinding associated " 
                + "with AdditionalInformation is: " 
                + mySoapBinding.Address);
        }
        catch (Exception e)
        {
         Console.WriteLine(e.ToString());
        }
    }
}

// </Snippet1>
