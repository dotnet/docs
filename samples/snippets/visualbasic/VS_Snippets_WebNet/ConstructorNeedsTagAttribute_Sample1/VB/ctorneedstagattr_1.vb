Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace CTorNeedsTagAtt

' <Snippet1>
 ' Attach the ConstructorNeedsTagAttribute to the custom Simple
 ' class, which is derived from the WebControl class. This 
 ' instance of the ConstructorNeedsTagAttribute class sets the
 ' NeedsTag property to true.
 <ConstructorNeedsTagAttribute(True)>  _
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class Simple
   Inherits WebControl

   Private NameTag As String = ""
   
   
   Public Sub New(tag As String)
      Me.NameTag = tag
   End Sub 'New
   
   Private UserMessage As String = Nothing
   
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
      output.Write("Testing the ConstructorNeedsTagAttribute Class.")
   End Sub 'Render
 End Class 'Simple
' </Snippet1>
End Namespace 'CTorNeedsTagAtt
