' System.Web.Description.ServiceDescription.Read(XmlReader)
' System.Web.Description.ServiceCollection.Item(string)
' System.Web.Description.ServiceCollection.Insert(int,Service)
' System.Web.Description.ServiceDescription.Write(XmlWriter)

' The following program demonstrates the properties of ServiceDescription and 
' ServiceCollection class.An XmlTextReader with the required url is created.
' An existing WSDL document is read.
' An existing service named "MathService" is removed from the collection and 
' A new Service object is constructed and added at index 1 of the Collection of Services.
' A new WSDL file is created as output.

Imports System
Imports System.Text
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyClass1
   
   Public Shared Sub Main()
      Try
' <Snippet1>
' <Snippet2>
         ' Create a new XmlTextWriter with specified URL.
         Dim myXmlReader As New XmlTextReader("All_VB.wsdl")
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read(myXmlReader)
         myServiceDescription.TargetNamespace = "http://tempuri.org/"
         
         ' Remove the service named MathService.
         Dim myServiceDescriptionCollection As ServiceCollection = _
            myServiceDescription.Services
         myServiceDescriptionCollection.Remove( _
            myServiceDescription.Services("MathService"))
' </Snippet2>
' </Snippet1>

' <Snippet3>
         Dim myService As New Service()
         myService.Name = "MathService"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:MathServiceSoap")

         ' Build a new Port for SOAP.
         Dim mySoapPort As New Port()
         mySoapPort.Name = "MathServiceSoap"
         mySoapPort.Binding = myXmlQualifiedName
         Dim mySoapAddressBinding As New SoapAddressBinding()
         mySoapAddressBinding.Location = _
            "http://localhost/ServiceDescription_Read/AddService_VB.asmx"
         mySoapPort.Extensions.Add(mySoapAddressBinding)

         ' Build a new Port for HTTP-GET.
         Dim myXmlQualifiedName2 As New _
            XmlQualifiedName("s0:MathServiceHttpGet")
         Dim myHttpGetPort As New Port()
         myHttpGetPort.Name = "MathServiceHttpGet"
         myHttpGetPort.Binding = myXmlQualifiedName2
         Dim myHttpAddressBinding As New HttpAddressBinding()
         myHttpAddressBinding.Location = _
            "http://localhost/ServiceDescription_Read/AddService_VB.asmx"
         myHttpGetPort.Extensions.Add(myHttpAddressBinding)

         ' Add the ports to the service.
         myService.Ports.Add(myHttpGetPort)
         myService.Ports.Add(mySoapPort)
         
         ' Add the service to the ServiceCollection.
         myServiceDescription.Services.Insert(1, myService)
' </Snippet3>

' <Snippet4>
         ' Create a new XmlTextWriter.
         Dim myWriter As New XmlTextWriter("output.wsdl", Encoding.UTF8)
         myWriter.Formatting = Formatting.Indented

         ' Write the WSDL.
         myServiceDescription.Write(myWriter)
' </Snippet4>
      Catch e As Exception
         Console.WriteLine("Exception: " + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyClass1
