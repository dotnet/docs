' System.Web.Services.Description.Service

'   The following sample demonstrates the class 'Service'.This sample reads the
'   contents of a file 'MathService.wsdl' into a 'ServiceDescription' instance. 
'   It gets the collection of Service instances from 'ServiceDescription'. It 
'   then removes a 'Service' from the collection and creates a new 'Service' and 
'   adds it into collection. It writes a new web service description file 'MathService_New.wsdl'.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyServiceClass
   Public Shared Sub Main()
      Try
         ' Read a WSDL document.
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_vb.wsdl")
         Dim myServiceCollection As ServiceCollection = _
            myServiceDescription.Services

         Dim noOfServices As Integer = myServiceCollection.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total Number of Services :" & noOfServices.ToString())

         ' Gets a reference to the service.
         Dim myOldService As Service = myServiceCollection(0)
         Console.WriteLine("No. of Ports in the Service" & _
            myServiceCollection(0).Ports.Count.ToString())
         Console.WriteLine("These are the ports in the service:")
         Dim i As Integer
         For i = 0 To myOldService.Ports.Count - 1
            Console.WriteLine("Port name: " & myOldService.Ports(i).Name)
         Next i
         Console.WriteLine("Service name: " & myOldService.Name)

         Dim myService As New Service()
         myService.Name = "MathService"

         ' Add the Ports to the newly created Service.
         Dim j As Integer
         For j = 0 To myOldService.Ports.Count - 1
            Dim PortName As String = myServiceCollection(0).Ports(j).Name
            Dim BindingName As String = _
               myServiceCollection(0).Ports(j).Binding.Name
            myService.Ports.Add(CreatePort(PortName, BindingName, _
               myServiceDescription.TargetNamespace))
         Next j

         Console.WriteLine("Newly created ports -")
         Dim k As Integer
         For k = 0 To myService.Ports.Count - 1
            Console.WriteLine("Port name: " & myOldService.Ports(k).Name)
         Next k 

         ' Add the extensions to the newly created Service.
         Dim noOfExtensions As Integer = myOldService.Extensions.Count
         Console.WriteLine("No. of extensions: " & noOfExtensions.ToString())
         If noOfExtensions > 0 Then
            Dim l As Integer
            For l = 0 To myOldService.Ports.Count - 1
               myService.Extensions.Add(myServiceCollection(0).Extensions(l))
            Next l
         End If 

         ' Remove the service from the collection.
         myServiceCollection.Remove(myOldService)

         ' Add the newly created service.
         myServiceCollection.Add(myService)
         
         myServiceDescription.Write("MathService_New.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception:" & e.Message)
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
         "http://localhost/ServiceClass/MathService.vb.asmx"
      myPort.Extensions.Add(mySoapAddressBinding)
      Return myPort
   End Function 'CreatePort
End Class 'MyServiceClass
' </Snippet1>
