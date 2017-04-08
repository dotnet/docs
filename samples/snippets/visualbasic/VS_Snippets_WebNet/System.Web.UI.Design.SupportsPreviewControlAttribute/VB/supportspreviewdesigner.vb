' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls
Imports System.Reflection

Namespace ControlDesignerSamples.VB

    ' Derive a simple Web control from Label to render a text string.
    ' Associate this control with the SimpleTextControlDesigner.
    <DesignerAttribute("ControlDesignerSamples.CS.SimpleTextControlDesigner"), _
    ToolboxData("<{0}:MyLabelControl Runat=""Server""><{0}:MyLabelControl>")> _
    Public Class MyLabelControl
        Inherits Label

        ' Use the Label control implementation, but associate
        ' the derived class with the custom control designer.
    End Class


    ' Mark the designer with the SupportsPreviewControlAttribute set
    ' to true.  This means the base.UsePreviewControl returns true,
    ' and base.ViewControl returns a temporary preview copy of the control.
    <SupportsPreviewControl(True)> _
    Public Class SimpleTextControlDesigner
        Inherits TextControlDesigner

        ' Override the base GetDesignTimeHtml method to display 
        ' the design time text in italics.
        Public Overrides Function GetDesignTimeHtml() As String
            Dim html As String = String.Empty

            Try
                ' Get the ViewControl for the associated control.
                Dim ctrl As Label = CType(ViewControl, Label)

                ' Set the default text, if necessary
                If ctrl.Text.Length = 0 Then
                    ctrl.Text = "Sample Text"
                End If

                ' Set the style to italic
                ctrl.Style.Add(HtmlTextWriterStyle.FontStyle, "italic")

                ' Let the base class create the HTML markup
                html = MyBase.GetDesignTimeHtml()
            Catch ex As Exception
                If String.IsNullOrEmpty(html) Then
                    ' Display the exception message
                    html = GetErrorDesignTimeHtml(ex)
                End If
            End Try

            Return html
        End Function

    End Class
End Namespace
' </Snippet1>