' System.Web.Services.Description.ServiceDescriptionImportstyle
' System.Web.Services.Description.ServiceDescriptionImportStyle.Client

'   The following program demonstrates the 'ServiceDescriptionImportstyle'
'   enumeration and 'Client' member of 'ServiceDescriptionImportstyle' in 
'   'System.Web.Services.Description' namespace. It creates a 
'   ServiceDescriptionImporter object from a .wsdl file and demonstrates
'   the usage of Client.

' <Snippet1>
Imports System.Web.Services.Description

Namespace MyServiceDescription
   Class MyImporter
      Public Shared Sub Main()
         Try
            Dim myServiceDescription As ServiceDescription = _
                                       ServiceDescription.Read("Sample_vb.wsdl")
            Dim myImporter As New ServiceDescriptionImporter()
            myImporter.ProtocolName = "Soap"
            myImporter.AddServiceDescription(myServiceDescription, "", "")
' <Snippet2>
            Dim myStyle As ServiceDescriptionImportstyle = myImporter.Style
            Console.WriteLine("Import style: " + myStyle.ToString())
' </Snippet2>
         Catch e As Exception
            Console.WriteLine("Following exception was thrown: " + e.ToString())
         End Try
      End Sub
   End Class
End Namespace 'MyServiceDescription
' </Snippet1>