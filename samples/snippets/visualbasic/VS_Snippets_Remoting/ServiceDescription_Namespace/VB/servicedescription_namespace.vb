' System.Web.Services.Description.ServiceDescription.Namespace

' The following example demonstrates 'Namespace' property of 'ServiceDescription' class.The input to the program is a 
' WSDL file 'MyWsdl.wsdl'.This program displays the Namespace of 'ServiceDescription' class.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description

Namespace ServiceDescription1

   Class MyService
      
      Shared Sub Main()
         Try
' <Snippet1>
            Dim myDescription As ServiceDescription = _
               ServiceDescription.Read("MyWsdl_VB.wsdl")
            Console.WriteLine("Namespace: " & ServiceDescription.Namespace)
' </Snippet1>
         Catch e As Exception
            Console.WriteLine("Exception: " + e.Message)
         End Try
      End Sub 'Main 
   End Class 'MyService
End Namespace 'ServiceDescription1
