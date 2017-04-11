' System.Web.Services.Description.Service.Ports
' System.Web.Services.Description.Service.Extensions
' System.Web.Services.Description.Service.Service()
' System.Web.Services.Description.Service.Name

' The following sample demonstrates the properties 'Ports','Extensions','Name' and
' constructor 'Service()'.This sample reads the contents of a file 'MathService_VB.wsdl'
' into a 'ServiceDescription' instance. It gets the collection of Service 
' instances from 'ServiceDescription'. It then removes a 'Service' from the collection and
' creates a new 'Service' and adds it into collection. It writes a new web service description 
' file 'MathService_New.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyServiceClass
   
   Public Shared Sub Main()
      Try
' <Snippet2>
' <Snippet3>
' <Snippet4>
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         Dim myServiceCollection As ServiceCollection = _
            myServiceDescription.Services
         
         Dim noOfServices As Integer = myServiceCollection.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of services: " & noOfServices.ToString())

         ' Get a reference to the service.
         Dim myOldService As Service = myServiceCollection(0)
         Console.WriteLine("No.of Ports in the Service" &  _
            myServiceCollection(0).Ports.Count.ToString())
         Console.WriteLine("These are the ports in the service:")
         Dim i As Integer
         For i = 0 To myOldService.Ports.Count - 1
            Console.WriteLine("Port name: " & myOldService.Ports(i).Name)
         Next i
         Console.WriteLine("Service name: " & myOldService.Name)
         
         Dim myService As New Service()
         myService.Name = "MathService"

         ' Add the ports to the newly created service.
         For i = 0 To myOldService.Ports.Count - 1
            Dim PortName As String = myServiceCollection(0).Ports(i).Name
            Dim BindingName As String = _
               myServiceCollection(0).Ports(i).Binding.Name
            myService.Ports.Add(CreatePort(PortName, BindingName, _
               myServiceDescription.TargetNamespace))
         Next i

         Console.WriteLine("Newly created ports -")
         For i = 0 To myService.Ports.Count - 1
            Console.WriteLine("Port Name: " & myOldService.Ports(i).Name)
         Next i 

         ' Add the extensions to the newly created service.
         Dim noOfExtensions As Integer = myOldService.Extensions.Count
         Console.WriteLine("No. of extensions: " & noOfExtensions.ToString())

         If noOfExtensions > 0 Then
            For i = 0 To myOldService.Ports.Count - 1
               myService.Extensions.Add(myServiceCollection(0).Extensions(i))
            Next i
         End If 

         ' Remove the service from the collection.
         myServiceCollection.Remove(myOldService)

         ' Add the newly created service.
         myServiceCollection.Add(myService)
         myServiceDescription.Write("MathService_New.wsdl")
' </Snippet2>
' </Snippet3>
' </Snippet4>
      Catch e As Exception
         Console.WriteLine("Exception: " & e.Message.ToString())
      End Try
   End Sub 'Main
   
   
   Public Shared Function CreatePort(PortName As String, _
         BindingName As String, targetNamespace As String) As Port
      Dim myPort As New Port()
      myPort.Name = PortName
      myPort.Binding = New XmlQualifiedName(BindingName, targetNamespace)

      ' Create a SoapAddress extensibility element to add to the port.
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = _
         "http://localhost/Service_Class/MathService_VB.asmx"
      myPort.Extensions.Add(mySoapAddressBinding)
      Return myPort
   End Function 'CreatePort
End Class 'MyServiceClass
' </Snippet1>
