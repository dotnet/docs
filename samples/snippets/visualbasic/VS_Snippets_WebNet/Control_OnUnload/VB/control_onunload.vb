' Snippet marked here to be grouped with Snippet1 in aspx file.

Imports System
Imports System.Web.UI
Imports System.IO

Namespace CustomControlNameSpace

    Public Class MyCustomControl
        Inherits Control
        Private _text As String

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        ' <Snippet2>
        ' Override the OnUnLoad method to set _text to
        ' a default value if it is null.
        Protected Overrides Sub OnUnload(ByVal e As EventArgs)
            MyBase.OnUnload(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub
        ' </Snippet2>

        ' <Snippet3>
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            If _text Is Nothing Then
                _text = "Here is some default text."
            End If
        End Sub
        ' </Snippet3>

        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            output.Write("<INPUT TYPE ='Text' name = " & Me.UniqueID & " Value = " & Me.Text & " >")
        End Sub
    End Class
End Namespace