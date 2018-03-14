'  System.Web.Services.Description.Read(StreamReader)

'   The following example demonstrates the 'Read(StreamReader)' method  of 
'   'ServiceDescription' class.A ServiceDescription instance is 
'   obtained from existing Wsdl.Name property of Bindings in the 
'   ServiceDescription is displayed to console.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Xml
Imports System.IO

Class MyService
   Shared Sub Main()
      Try
' <Snippet1>
         ' Create a StreamReader to read a WSDL file.
         Dim myStreamReader As New StreamReader("MyWsdl.wsdl")
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read(myStreamReader)
         Console.WriteLine("Bindings are :")

         ' Display the Bindings present in the WSDL file.
         Dim myBinding As Binding
         For Each myBinding In myDescription.Bindings
            Console.WriteLine(myBinding.Name)
         Next myBinding
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception : " & e.Message)
      End Try
   End Sub 'Main
End Class 'MyService
