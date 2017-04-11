' <Snippet1>

Imports System.ComponentModel
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls

    ' Set ControlValueProperty attribute to specify the default
    ' property of this control that a ControlParameter object 
    ' binds to at run time.
    <DefaultProperty("Text"), ControlValueProperty("Text", "DefaultText")> Public Class SimpleCustomControl
        Inherits System.Web.UI.WebControls.WebControl

        Dim _text As String

        <Bindable(True), Category("Appearance"), DefaultValue("")> Property [Text]() As String
            Get
                Return _text
            End Get

            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Protected Overrides Sub Render(ByVal output As System.Web.UI.HtmlTextWriter)
            output.Write([Text])
        End Sub

    End Class

End Namespace

' </Snippet1>