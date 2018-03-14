' System.Web.Services.Description.ServiceDescription.Write(FileName)
' System.Web.Services.Description.ServiceCollection.Remove
' System.Web.Services.Description.ServiceCollection.Item(int)
' System.Web.Services.Description.ServiceDescription.Services
' System.Web.Services.Description.ServiceDescription.TargetNamespace
' System.Web.Services.Description.ServiceCollection.Add
'
'   The following example demonstrates methods and properties of 
'   ServiceDescription and ServiceCollection classes.
'   A new WSDL is read and the existing service "MathService" in the 
'   ServiceCollection is removed.The service by default is defined for 
'   SOAP,HttpGet,HttpPost.A new Service defined for SOAP and HttpGet is 
'   constructed and added to the ServiceCollection.
'   The programs writes a new web service description file.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyClass1

   Public Shared Sub Main()
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
      ' Read a ServiceDescription from existing WSDL.
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("Input.vb.wsdl")
      myServiceDescription.TargetNamespace = "http://tempuri.org/"
' </Snippet5>

      ' Get the ServiceCollection of the ServiceDescription.
      Dim myServiceCollection As ServiceCollection = _
         myServiceDescription.Services

      ' Remove the Service at index 0 of the collection.
      myServiceCollection.Remove(myServiceDescription.Services.Item(0))
' </Snippet4>
' </Snippet3>
' </Snippet2>

' <Snippet6>
      ' Build a new Service.
      Dim myService As New Service()
      myService.Name = "MathService"
      Dim myXmlQualifiedName As New XmlQualifiedName("s0:MathServiceSoap")

      ' Build a new Port for SOAP.
      Dim mySoapPort As New Port()

      mySoapPort.Name = "MathServiceSoap"

      mySoapPort.Binding = myXmlQualifiedName

      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = _
         "http://localhost/ServiceCollection_Item/AddSub.vb.asmx"
      mySoapPort.Extensions.Add(mySoapAddressBinding)

      ' Build a new Port for HTTP-GET.
      Dim myXmlQualifiedName2 As _
         New XmlQualifiedName("s0:MathServiceHttpGet")

      Dim myHttpGetPort As New Port()
      myHttpGetPort.Name = "MathServiceHttpGet"
      myHttpGetPort.Binding = myXmlQualifiedName2
      Dim myHttpAddressBinding As New HttpAddressBinding()
      myHttpAddressBinding.Location = _
         "http://localhost/ServiceCollection_Item/AddSub.vb.asmx"
      myHttpGetPort.Extensions.Add(myHttpAddressBinding)

      ' Add the ports to the service.
      myService.Ports.Add(myHttpGetPort)
      myService.Ports.Add(mySoapPort)

      ' Add the service to the ServiceCollection.
      myServiceCollection.Add(myService)
' </Snippet6>

      ' Write to a new WSDL file.
      myServiceDescription.Write("output.wsdl")
' </Snippet1>
   End Sub 'Main
End Class 'MyClass1
