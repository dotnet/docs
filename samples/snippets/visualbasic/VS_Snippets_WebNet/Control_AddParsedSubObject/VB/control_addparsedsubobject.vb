' System.Web.UI.Control.AddParsedSubObject;

'   The following example demonstrates the method 'AddParsedSubObject' of class
'   'Control'. The program associates a custom control builder using attributes 
'   to a custom control 'MyControl'. 'MyControl' class internally maintains an 
'   ArrayList to store it's child controls before they are added to the
'   ControlCollection.

'   The Control Builder ensures that only tagnames "myitem" would be passed on 
'   to make controls of type TextBox. AddParsedSubObject has been overridden to
'   add all such controls parsed into the internal ArrayList.
'   These are then added to the ControlCollection in CreateChildControl.

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ControlSample

' <Snippet1>
   ' Custom ControlBuilder class. Interprets nested tag name "myitem" as a textbox.
   Public Class MyControlBuilder
      Inherits ControlBuilder

      Public Overrides Function GetChildControlType(tagName As String, _
                                attributes As IDictionary) As Type
         If String.Compare(tagName, "myitem", True) = 0 Then
            Return GetType(TextBox)
         End If
         Return Nothing
      End Function
   End Class

   <ControlBuilderAttribute(GetType(MyControlBuilder))> Public Class MyControl
      Inherits Control
      ' Stores all the controls specified as nested tags.
      Private items As New ArrayList()

      ' This function is internally invoked by IParserAccessor.AddParsedSubObject(Object).
      Protected Overrides Sub AddParsedSubObject(obj As Object)
         If TypeOf obj Is TextBox Then
            items.Add(obj)
         End If
      End Sub

     ' Override 'CreateChildControls'.
      Protected Overrides Sub CreateChildControls()
         Dim myEnumerator As System.Collections.IEnumerator = items.GetEnumerator()
         While myEnumerator.MoveNext()
            Me.Controls.Add(CType(myEnumerator.Current, TextBox))
         End While
      End Sub
   End Class
' </Snippet1>

End Namespace
