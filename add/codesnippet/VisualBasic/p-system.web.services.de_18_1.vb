Imports System
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic

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
   End Sub 'Main

   ' Prints documentation associated with a wsdl element.
   Public Shared Sub PrintDocumentation(myItem As DocumentableItem)
      Console.WriteLine(ControlChars.Tab + myItem.Documentation)
   End Sub 'PrintDocumentation
End Class 'DocumentableItemSample