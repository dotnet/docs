Imports Microsoft.VisualBasic

'<Snippet1>

Public Class CustomTextControl
    Inherits System.Web.UI.Control
    Implements System.Web.UI.ITextControl

    Private _text As String

    Public Property Text() As String Implements System.Web.UI.ITextControl.Text
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            If (value <> Nothing) Then
                _text = value
            Else
                _text = "No Value."
            End If
        End Set
    End Property

    ' Provide the remaining code to implement a text control.
End Class
'</Snippet1>