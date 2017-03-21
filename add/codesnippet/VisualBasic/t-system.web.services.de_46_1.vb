Imports System
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
            Dim myStyle As ServiceDescriptionImportStyle = myImporter.Style
            Console.WriteLine("Import style: " + myStyle.ToString())
         Catch e As Exception
            Console.WriteLine("Following exception was thrown: " + e.ToString())
         End Try
      End Sub 'Main
   End Class 'MyImporter
End Namespace 'MyServiceDescription