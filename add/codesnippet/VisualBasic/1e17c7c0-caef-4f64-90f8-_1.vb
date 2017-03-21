 ' Create a custom ControlBuilder that interprets nested elements
 ' named myitem as TextBoxes. If this class is called in a 
 ' ControlBuilderAttribute applied to a custom control, when
 ' that control is created in a page and it contains child elements
 ' that are named myitem, the child elements will be rendered as 
 ' TextBox server controls. This control builder also ignores literal
 ' strings between elements when it is associated with a control.

 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class MyItemControlBuilder
   Inherits ControlBuilder
   
   ' Override the GetChildControlType method to detect
   ' child elements named myitem.
   Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type
      If [String].Compare(tagName, "myitem", True) = 0 Then
         Return GetType(TextBox)
      End If
      Return Nothing
   End Function 'GetChildControlType
   
   
   ' Override the AppendLiteralString method so that literal
   ' text between rows of controls are ignored.  
   Public Overrides Sub AppendLiteralString(s As String)
   End Sub 'AppendLiteralString
 End Class 'MyItemControlBuilder ' Ignores literals between rows.