' System.Web.Services.Description.ServiceDescription.Imports

' The following program demonstrates the property 'Imports' of 'ServiceDescription' class.
' The input to the program is a WSDL file 'ServiceDescription_Imports_Input_VB.wsdl' which 
' is not having the import element. A new 'Import' is defined and added to the new modified 
' 'ServiceDescription_Imports_Output_VB.wsdl' file.

Imports System
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Xml

Class MyServiceDescription
   
   Public Shared Sub Main()
' <Snippet1>
      Dim myServiceDescription As New ServiceDescription()
      myServiceDescription = _
         ServiceDescription.Read("ServiceDescription_Imports_Input_VB.wsdl")
      Dim myImportCollection As ImportCollection = myServiceDescription.Imports

      ' Create an Import.
      Dim myImport As New Import()
      myImport.Namespace = myServiceDescription.TargetNamespace

      ' Set the location for the Import.
      myImport.Location = "http://www.contoso.com/"
      myImportCollection.Add(myImport)
      myServiceDescription.Write("ServiceDescription_Imports_Output_VB.wsdl")
      myImportCollection.Clear()
      myServiceDescription = _
         ServiceDescription.Read("ServiceDescription_Imports_Output_VB.wsdl")
      myImportCollection = myServiceDescription.Imports
      Console.WriteLine( _
         "The Import elements added to the ImportCollection are: ")
      Dim i As Integer
      For i = 0 To myImportCollection.Count - 1
         Console.WriteLine((i + 1).ToString() & ". " & _
            myImportCollection(i).Location)
      Next i
' </Snippet1>
   End Sub 'Main 
End Class 'MyServiceDescription
