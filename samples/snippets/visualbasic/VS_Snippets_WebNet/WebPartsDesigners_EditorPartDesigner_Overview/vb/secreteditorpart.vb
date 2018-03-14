' <snippet1>
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web.UI.Design.WebControls.WebParts

' <summary>
' SecretEditorPart is a custom EditorPart control that
' allows the end user to change the ToolTip property of
' a control by typing the value into a TextBox. 
' SecretEditorPartDesigner hides the TextBox at design
' time via the view control and replaces it with the 
' words "The textbox is now hidden."
' </summary>
Namespace Samples.AspNet.VB.Controls
    <Designer(GetType(SecretEditorPartDesigner))> _
    Public Class SecretEditorPart
        Inherits EditorPart
        Public UseCustom As New CheckBox()
        Public TTTextBox As New TextBox()

        Protected Overrides Sub CreateChildControls()
            MyBase.CreateChildControls()
            Controls.Add(UseCustom)
            Dim lApply As New Literal()
            lApply.Text = "Apply custom ToolTip<br />"
            Controls.Add(lApply)
            Controls.Add(TTTextBox)
        End Sub

        Public Overrides Function ApplyChanges() As Boolean
            EnsureChildControls()
            Try
                WebPartToEdit.ToolTip = TTTextBox.Text
            Catch
                Return False
            End Try
            Return True
        End Function

        Public Overrides Sub SyncChanges()
            ' Abstract method not implemented for this example
            Return
        End Sub
    End Class

    Public Class SecretEditorPartDesigner
        Inherits EditorPartDesigner
        Public Overrides Sub Initialize(component As IComponent)
            ' Validate the associated control
            If Not (TypeOf component Is SecretEditorPart) Then
                Dim msg As String = "The associated control must be of type 'SecretEditorPart'"
                Throw New ArgumentException(msg)
            End If
            MyBase.Initialize(component)
        End Sub

        Public Overrides Function GetDesignTimeHtml() As String
            ' Access the view control.
            Dim sep As SecretEditorPart = DirectCast(ViewControl, SecretEditorPart)

            ' Hide the textbox.
            sep.TTTextBox.Visible = False

            ' Now generate the base rendering.
            Dim designTimeHtml As String = MyBase.GetDesignTimeHtml()

            ' Insert some text.
            Dim segment As String = "</div>"
            designTimeHtml = designTimeHtml.Replace(segment, "The textbox is now hidden." & segment)

            ' Return the modified rendering.
            Return designTimeHtml
        End Function
    End Class
End Namespace
' </snippet1>