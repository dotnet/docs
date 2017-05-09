Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace MyUserControl

' <Snippet1>      
' Attach the ConstructorNeedsTagAttribute to the custom
' SimpleControl, which is derived from WebControl. When
' this version of the constructor is used, the NeedsTag
' property is automatically set to false; therefore,
' this class does not need a tag attribute.
<ConstructorNeedsTagAttribute()>  _
<AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
Public NotInheritable Class SimpleControl
   Inherits WebControl
   
   Private UserMessage As [String] = Nothing
   
   ' Create a property named ControlValue.
   
   Public Property ControlValue() As [String]
      Get
         Return UserMessage
      End Get
      Set
         UserMessage = value
      End Set
   End Property
   
   
   Protected Overrides Sub Render(output As HtmlTextWriter)
      output.Write("Testing the ConstructorNeedsTagAttribute class.")
   End Sub 'Render 
 End Class 'SimpleControl
' </Snippet1>
End Namespace 'MyUserControl