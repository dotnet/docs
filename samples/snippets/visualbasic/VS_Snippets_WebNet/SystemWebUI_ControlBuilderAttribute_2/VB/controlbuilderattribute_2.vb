
' <snippet1>

'File name: controlBuilderAttribute.vb.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections



Namespace CustomControls

Public Class MyVB_Item: Inherits Control
      
      Private _message As String
      
      Public Property Message() As String
         Get
            Return _message
         End Get
         Set
            _message = value
         End Set
      End Property
   End Class 'MyVB_Item
   
   Public Class VB_CustomParseControlBuilder: Inherits ControlBuilder

      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>  _
      Public Overrides Function GetChildControlType(TagName As String, attributes As IDictionary) As Type
          If (TagName = "customitem")  Then
            Return GetType(CustomControls.MyVB_Item)
         End If
         Return Nothing
      End Function 'GetChildControlType
   End Class 'CustomParseControlBuilder
   
   <ControlBuilderAttribute(GetType(VB_CustomParseControlBuilder))>  Public Class MyVB_CustomParse: Inherits Control
      
      Private _items As New ArrayList
      Private _selectedIndex As Integer = 0
      
      
      Public Property SelectedIndex() As Integer
         Get
            Return _selectedIndex
         End Get
         Set
            _selectedIndex = value
         End Set
      End Property
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub AddParsedSubObject(obj As Object)
         If TypeOf obj Is MyVB_Item Then
            _items.Add(obj)
         End If
      End Sub 'AddParsedSubObject
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(output As HtmlTextWriter)        
        output.Write(("<span style='background-color:aqua; color:red; font:8pt tahoma, verdana;'><b>" + CType(_items(SelectedIndex), MyVB_Item).Message + "</b></span>"))
      End Sub 'Render
   End Class 'MyVB_CustomParse 
   
End Namespace 'CustomControls

' </snippet1>
