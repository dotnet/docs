// System.Web.Description.ServiceDescription.Read(XmlReader)
// System.Web.Description.ServiceCollection.Item(string)
// System.Web.Description.ServiceCollection.Insert(int,Service)
// System.Web.Description.ServiceDescription.Write(XmlWriter)

/*
   The following program demonstrates the properties of ServiceDescription and 
   ServiceCollection class.An XmlTextReader with the required url is created.
   An existing WSDL document is read.
   An existing service named "MathService" is removed from the collection and 
   A new Service object is constructed and added at index 1 of the Collection of Services.
   A new WSDL file is created as output.
*/

using System;
using System.Text;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass
{
   public static void Main()
   {
   try
   {
// <Snippet1>
// <Snippet2>
      // Create a new XmlTextWriter with specified URL.
      XmlTextReader myXmlReader = new XmlTextReader("All_CS.wsdl");
      ServiceDescription myServiceDescription = 
         ServiceDescription.Read(myXmlReader);
      myServiceDescription.TargetNamespace = "http://tempuri.org/";

      // Remove the service named MathService.
      ServiceCollection myServiceDescriptionCollection =
         myServiceDescription.Services;
      myServiceDescriptionCollection.Remove(
         myServiceDescription.Services["MathService"]);
// </Snippet2>
// </Snippet1>

// <Snippet3>
      Service myService = new Service();
      myService.Name = "MathService";
      XmlQualifiedName myXmlQualifiedName = 
         new XmlQualifiedName("s0:MathServiceSoap");

      // Build a new Port for SOAP.
      Port mySoapPort = new Port();
      mySoapPort.Name = "MathServiceSoap";
      mySoapPort.Binding = myXmlQualifiedName;
      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location =
         "http://localhost/ServiceDescription_Read/AddService_CS.asmx";
      mySoapPort.Extensions.Add(mySoapAddressBinding);

      // Build a new Port for HTTP-GET.
      XmlQualifiedName myXmlQualifiedName2 = 
         new XmlQualifiedName("s0:MathServiceHttpGet");
      Port myHttpGetPort = new Port();
      myHttpGetPort.Name = "MathServiceHttpGet";
      myHttpGetPort.Binding = myXmlQualifiedName2;
      HttpAddressBinding myHttpAddressBinding = new HttpAddressBinding();
      myHttpAddressBinding.Location = 
         "http://localhost/ServiceDescription_Read/AddService_CS.asmx";
      myHttpGetPort.Extensions.Add(myHttpAddressBinding);

      // Add the ports to the service.
      myService.Ports.Add(myHttpGetPort);
      myService.Ports.Add(mySoapPort);

      // Add the service to the ServiceCollection.
      myServiceDescription.Services.Insert(1,myService);
// </Snippet3>

// <Snippet4>
      // Create a new XmlTextWriter object.
     XmlTextWriter myWriter = new XmlTextWriter("output.wsdl",Encoding.UTF8);
     myWriter.Formatting = Formatting.Indented; 

     // Write the WSDL.
     myServiceDescription.Write(myWriter);
// </Snippet4>
  }
  catch(Exception e)
  {
   Console.WriteLine("Exception: " + e.Message);
  }
   }
}
