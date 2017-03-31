' System.Web.Services.Description.ServiceCollection.Contains(Service)
' System.Web.Services.Description.ServiceCollection.IndexOf(service)
' System.Web.Services.Description.ServiceCollection.CopyTo(System[],int)

'   The following program demonstrates the methods of
'   ServiceDescription and ServiceCollection class. An existing WSDL document
'   is read.An exiting service named "MathService" is removed from the
'   collection. A new Service object is constructed and added at index 1 of the
'   Collection .A new WSDL file is created as output.

Imports System
Imports System.Text
Imports System.Web.Services.Description
Imports System.Collections
Imports System.IO
Imports System.Xml

Class ServiceDescription_Sample
   Public Shared Sub Main()
      Try
         ' Read the Existing Wsdl.
         Dim myServiceDescription As ServiceDescription = _
                           ServiceDescription.Read("AddSubtractService_vb.wsdl")
         ' Remove the service named "MathService".
         Dim myServiceDescriptionCollection As ServiceCollection = _
                                                   myServiceDescription.Services
         myServiceDescriptionCollection.Remove(myServiceDescription.Services("MathService"))
         ' Build a new Service.
         Dim myService As New Service()
         myService.Name = "MathService"

         Dim myXmlQualifiedName As New XmlQualifiedName("s0:MathServiceSoap")
         ' Build a new Port for Soap.
         Dim mySoapPort As New Port()
         mySoapPort.Name = "MathServiceSoap"
         mySoapPort.Binding = myXmlQualifiedName
         Dim mySoapAddressBinding As New SoapAddressBinding()
         mySoapAddressBinding.Location = _
            "http://localhost/ServiceCollection_CopyTo/AddSubtractService_vb.asmx"
         mySoapPort.Extensions.Add(mySoapAddressBinding)

         ' Build a new Port for HttpGet.
         Dim myXmlQualifiedName2 As New XmlQualifiedName("s0:MathServiceHttpGet")
         Dim myHttpGetPort As New Port()
         myHttpGetPort.Name = "MathServiceHttpGet"
         myHttpGetPort.Binding = myXmlQualifiedName2
         Dim myHttpAddressBinding As New HttpAddressBinding()
         myHttpAddressBinding.Location = _
            "http://localhost/ServiceCollection_CopyTo/AddSubtractService_vb.asmx"
         myHttpGetPort.Extensions.Add(myHttpAddressBinding)
         ' Build a new Port for HttpPost.
         Dim myXmlQualifiedName3 As New XmlQualifiedName("s0:MathServiceHttpPost")
         ' Build a new Port for Soap.
         Dim myHttpPostPort As New Port()
         myHttpPostPort.Name = "MathServiceHttpPost"
         myHttpPostPort.Binding = myXmlQualifiedName3
         Dim myHttpAddressBinding1 As New HttpAddressBinding()
         myHttpAddressBinding1.Location = _
            "http://localhost/ServiceCollection_CopyTo/AddSubtractService_vb.asmx"
         myHttpPostPort.Extensions.Add(myHttpAddressBinding1)

         ' Add the ports to the service.
         myService.Ports.Add(mySoapPort)
         myService.Ports.Add(myHttpGetPort)
         myService.Ports.Add(myHttpPostPort)
         ' Add the Service to the ServiceCollection.
         myServiceDescription.Services.Insert(1, myService)

         Dim myStreamWriter As New StreamWriter("output.wsdl")
         ' Output the Wsdl.
         myServiceDescription.Write(myStreamWriter)
         myStreamWriter.Close()

' <Snippet1>
' <Snippet2>
         If myServiceDescription.Services.Contains(myService) Then
            Console.WriteLine( _
               "The mentioned service Exists at index {0} in the WSDL.", _
               myServiceDescription.Services.IndexOf(myService))
' <Snippet3>
            Dim myServiceArray(myServiceDescription.Services.Count - 1) _
            As Service

            ' Copy the services into an array.
            myServiceDescription.Services.CopyTo(myServiceArray, 0)
            Dim myEnumerator As IEnumerator = myServiceArray.GetEnumerator()
            Console.WriteLine("The names of services in the array are")
            While myEnumerator.MoveNext()
               Dim myService1 As Service = CType(myEnumerator.Current, Service)
               Console.WriteLine(myService1.Name)
            End While
' </Snippet3>
         Else
            Console.WriteLine("Service does not exist in the WSDL.")
         End If
' </Snippet2>
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception Caught! " + e.Message)
      End Try
   End Sub 'Main
End Class 'ServiceDescription_Sample
