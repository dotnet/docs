Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VS.Controls
    ' <Snippet2>
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLinkButtonAddParsedSubObject
        Inherits System.Web.UI.WebControls.LinkButton

        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            ' If the server control contains any child controls.
            If Me.HasControls() Then

                ' Notify the base server control that an element, either XML or HTML, 
                ' was parsed, and adds the element to the server control's 
                ' ControlCollection object.
                MyBase.AddParsedSubObject(obj)
                ' Else the server control doesn't contain any child controls.
            Else
                ' If the parsed element is a LiteralControl.
                If TypeOf obj Is System.Web.UI.LiteralControl Then

                    ' Set the server control's Text property to the parsed element's Text value.
                    Me.Text = CType(obj, System.Web.UI.LiteralControl).Text

                    ' Else the parsed element is not a LiteralControl.
                Else
                    ' If the server control has a value in the the Text property.
                    Dim currentText As String = Me.Text
                    If currentText.Length <> 0 Then

                        ' Set the server control's Text property to an empty string.
                        Me.Text = System.String.Empty

                        ' Notify the base server control that a new LiteralControl was parsed, 
                        ' and adds the element to the server control's ControlCollection object.
                        MyBase.AddParsedSubObject(New System.Web.UI.LiteralControl(currentText))
                    End If
                    MyBase.AddParsedSubObject(obj)
                End If
            End If
        End Sub
    End Class
    ' </Snippet2>
End Namespace