// System.Web.Services.Description.ServiceDescription.Extensions
// System.Web.Services.Description.ServiceDescription.RetrievalUrl

/* The following program demonstrates properties 'Extensions', 'RetrievalUrl' of 
   'ServiceDescription' class. The input to the program is a WSDL file
   'ServiceDescription_Extensions_Input_cs.wsdl'. This program adds one object 
   to the extensions collection and displays the count and set the 'RetrievalURL' and displays.
*/

using System;
using System.Web.Services;
using System.Web.Services.Description;

class MyServiceDescription
{
   public static void Main()
   {
// <Snippet1>
// <Snippet2>
      ServiceDescription myServiceDescription = new ServiceDescription();
      myServiceDescription = 
         ServiceDescription.Read("ServiceDescription_Extensions_Input_cs.wsdl");
      Console.WriteLine(
         myServiceDescription.Bindings[1].Extensions[0].ToString());
      SoapBinding mySoapBinding = new SoapBinding();
      mySoapBinding.Required = true;
      SoapBinding mySoapBinding1 = new SoapBinding();
      mySoapBinding1.Required = false;
      myServiceDescription.Extensions.Add(mySoapBinding);
      myServiceDescription.Extensions.Add(mySoapBinding1);
      foreach(ServiceDescriptionFormatExtension 
         myServiceDescriptionFormatExtension
         in myServiceDescription.Extensions)
      {
         Console.WriteLine("Required: " + 
            myServiceDescriptionFormatExtension.Required);
      }
      myServiceDescription.Write(
         "ServiceDescription_Extensions_Output_cs.wsdl");
      myServiceDescription.RetrievalUrl = "http://www.contoso.com/";
      Console.WriteLine("Retrieval URL is: " + 
         myServiceDescription.RetrievalUrl);
// </Snippet2>
// </Snippet1>
   }
}
