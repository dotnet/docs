Imports System
Imports System.Collections
Imports System.Web.UI


' Compile this same using the following command line:
'   vbc /t:exe /out:objectstateformattertest.exe objectstateformattertest.vb

Public Class ObjectStateFormatterTest
   
   
   Public Shared Sub Main()
      
      
      Dim SortDirection As String = "ASC"
      Dim SelectedColumn As String = "Employee"
      Dim CurrentPage As Integer = 1
      
' <snippet1>
      Dim controlProperties As New ArrayList(3)
      
      controlProperties.Add(SortDirection)
      controlProperties.Add(SelectedColumn)
      controlProperties.Add(CurrentPage.ToString())
      
      ' Create an ObjectStateFormatter to serialize the ArrayList.
      Dim formatter As New ObjectStateFormatter()
      
      ' Call the Serialize method to serialize the ArrayList to a Base64 encoded string.
      Dim base64StateString As String = formatter.Serialize(controlProperties)

' </snippet1>      
   End Sub 'Main

   
   
' <snippet2>
   Private Function LoadControlProperties(serializedProperties As String) As ICollection
      
      Dim controlProperties As ICollection = Nothing
      
      ' Create an ObjectStateFormatter to deserialize the properties.
      Dim formatter As New ObjectStateFormatter()
      
      ' Call the Deserialize method.
      controlProperties = CType(formatter.Deserialize(serializedProperties), ArrayList)
      
      Return controlProperties
   End Function 'LoadControlProperties   
' </snippet2>   

End Class 'ObjectStateFormatterTest 