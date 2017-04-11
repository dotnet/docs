' System.Web.Services.Description.ServiceDescriptionImportWarnings.NoCodeGenerated
' System.Web.Services.Description.ServiceDescriptionImportWarnings.NoMethodsGenerated
' System.Web.Services.Description.ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored
' System.Web.Services.Description.ServiceDescriptionImportWarnings.OptionalExtensionsIgnored
' System.Web.Services.Description.ServiceDescriptionImportWarnings.RequiredExtensionsIgnored
' System.Web.Services.Description.ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored

' The following program demonstrates the enum values of 'ServiceDescriptionImportWarnings'.
' 'Import' method of 'ServiceDescriptionImporter' will give the enumaration. The user selected
' option will help in taking the related wsdl file and returns the corresponding warning which
' is displayed on the console.


Imports System
Imports System.Security.Permissions
Imports System.Web.Services.Description
Imports System.CodeDom
Imports Microsoft.VisualBasic


Public Class ServiceDescriptionImportWarnings_Enum
   
   Public Shared Sub Main()
      DisplayWarning("ServiceDescriptionImportWarnings_NoCodeGenerated.wsdl")
      DisplayWarning("ServiceDescriptionImportWarnings_NoMethodsGenerated.wsdl")
      DisplayWarning("ServiceDescriptionImportWarnings_UnsupportedOperationsIgnored.wsdl")
      DisplayWarning("ServiceDescriptionImportWarnings_OptionalExtensionsIgnored.wsdl")
   End Sub 'Main
   
   <SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted:=true)> _
   Public Shared Sub DisplayWarning(myWSDLFileName As String)
' <Snippet1>
      Dim myDisplay As [String]
      ' Read wsdl file.
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read(myWSDLFileName)
      
      Dim myServiceDescriptionImporter As New ServiceDescriptionImporter()
      
      ' Add 'myServiceDescription' to 'myServiceDescriptionImporter'.
      myServiceDescriptionImporter.AddServiceDescription(myServiceDescription, "", "")
      
      myServiceDescriptionImporter.ProtocolName = "HttpGet"
      Dim myCodeNamespace As New CodeNamespace()
      Dim myCodeCompileUnit As New CodeCompileUnit()
      
      ' Invoke 'Import' method.
      Dim myWarning As ServiceDescriptionImportWarnings = myServiceDescriptionImporter.Import(myCodeNamespace, myCodeCompileUnit)
      
      Select Case myWarning
         Case ServiceDescriptionImportWarnings.NoCodeGenerated
            myDisplay = "NoCodeGenerated"
         Case ServiceDescriptionImportWarnings.NoMethodsGenerated
            myDisplay = "NoMethodsGenerated"
         Case ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored
            myDisplay = "UnsupportedOperationsIgnored"
         Case ServiceDescriptionImportWarnings.OptionalExtensionsIgnored
            myDisplay = "OptionalExtensionsIgnored"
         Case ServiceDescriptionImportWarnings.RequiredExtensionsIgnored
            myDisplay = "RequiredExtensionsIgnored"
         Case ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored
            myDisplay = "UnsupportedBindingsIgnored"
         Case Else
            myDisplay = "General Warning"
      End Select
      Console.WriteLine("Warning : " + myDisplay)
' </Snippet1>
   End Sub 'GenerateException 

End Class 'ServiceDescriptionImportWarnings_Enum 

