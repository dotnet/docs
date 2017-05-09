'  System.Web.Services.Description.Read(TextReader)

'   The following example demonstrates the 'Read(TextReader)' method  of 
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
         Dim myDescription As New ServiceDescription()

         ' Create a StreamReader to read a WSDL file.
         Dim myTextReader = New StreamReader("MyWsdl.wsdl")
         myDescription = ServiceDescription.Read(myTextReader)
         Console.WriteLine("Bindings are: ")

         ' Display the Bindings present in the WSDL file.
         Dim myBinding As Binding
         For Each myBinding In myDescription.Bindings
            Console.WriteLine(myBinding.Name)
         Next myBinding
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception: " + e.Message)
      End Try
   End Sub 'Main
End Class 'MyService
