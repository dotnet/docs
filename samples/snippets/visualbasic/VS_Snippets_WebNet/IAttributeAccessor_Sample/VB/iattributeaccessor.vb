' <Snippet1>
' The following class creates a custom ASP.NET server control that implements
' the IAttributeAccessor interface. It creates a MyTextBox class that contains
' Width and Text properties that get and set their values from view state.
' Pages that use this control create an instance of this control and set the
' Width property using the IAttributeAccessor.SetAttribute method. 
' The page then displays the values of the Text and Width properties 
' using the IAttributeAccessor.GetAttribute method.
' When compiled, this assembly is named MyAttributeAccessor.
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

Namespace AttributeAccessor

 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class MyTextBox
   Inherits Control
   Implements IAttributeAccessor 

   ' Declare the Width property.   
   Public Property Width() As String
      Get
         Return CType(ViewState("Width"), String)
      End Get
      Set
         ViewState("Width") = value
      End Set
   End Property
   
   ' Declare the Text property.
   
   Public Property Text() As String
      Get
         Return CType(ViewState("Text"), String)
      End Get
      Set
         ViewState("Text") = value
      End Set
   End Property
   
   ' <snippet2>
   ' Implement the SetAttribute method for the control. When
   ' this method is called from a page, the control's properties
   ' are set to values defined in the page.
   Public Sub SetAttribute(name As String, value1 As String) Implements IAttributeAccessor.SetAttribute
      ViewState(name) = value1
   End Sub 'SetAttribute
   
   ' </snippet2>
   ' <snippet3>
   ' Implement the GetAttribute method for the control. When
   ' this method is called from a page, the values for the control's
   ' properties can be displayed in the page.
   Public Function GetAttribute(name As String) As String Implements IAttributeAccessor.GetAttribute
      Return CType(ViewState(name), String)
   End Function 'GetAttribute
   
   ' </snippet3>
   Protected Overrides Sub Render(output As HtmlTextWriter)
      output.Write(("<input type=text id= " + Me.UniqueID))
      output.Write((" Value='" + Me.Text))
      output.Write(("' Size=" + Me.Width + ">"))
   End Sub 'Render
 End Class 'MyTextBox
End Namespace 'AttributeAccessor
' </Snippet1>