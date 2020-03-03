' System.Web.Services.Description.DocumentableItem.Documentation;

' The following program demonstrates the property 'Documentation' of abstract class
' 'DocumentableItem'. The program reads a wsdl document "MathService_vb.wsdl" and
' instantiates a ServiceDescription instance from the WSDL document.
' This program demonstrates a generic utility function which can accept any of Types,PortType and Binding 
' classes as parameters.

' <Snippet1>
Imports System.Web.Services.Description

Class DocumentableItemSample
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
                           ServiceDescription.Read("MathService_vb.wsdl")
      Console.WriteLine("Documentation Element for type is ")
      PrintDocumentation(myServiceDescription.Types)
      Dim myPortType As PortType
      For Each myPortType In  myServiceDescription.PortTypes
         Console.WriteLine("Documentation Element for Port Type {0} is ", myPortType.Name)
         PrintDocumentation(myPortType)
      Next myPortType
      Dim myBinding As Binding
      For Each myBinding In  myServiceDescription.Bindings
         Console.WriteLine("Documentation Element for Port Type {0} is ", myBinding.Name)
         PrintDocumentation(myBinding)
      Next myBinding
   End Sub

   ' Prints documentation associated with a wsdl element.
   Public Shared Sub PrintDocumentation(myItem As DocumentableItem)
      Console.WriteLine(ControlChars.Tab + myItem.Documentation)
   End Sub
End Class
' </Snippet1>