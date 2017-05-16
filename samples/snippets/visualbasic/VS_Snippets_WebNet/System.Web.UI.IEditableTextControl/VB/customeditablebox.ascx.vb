Imports Microsoft.VisualBasic

' <Snippet1>
Public Class customeditablebox
    Inherits System.Web.UI.UserControl
    Implements System.Web.UI.IEditableTextControl

    Private Shared ReadOnly EventCustomTextChanged As New Object

    Public Custom Event TextChanged As EventHandler _
      Implements System.Web.UI.IEditableTextControl.TextChanged
        AddHandler(ByVal value As EventHandler)
            Events.AddHandler(EventCustomTextChanged, value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Events.RemoveHandler(EventCustomTextChanged, value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)

        End RaiseEvent
    End Event

    Public Property Text() As String _
      Implements System.Web.UI.IEditableTextControl.Text
        Get
            ' Provide implementation.
            Return String.Empty
        End Get
        Set(ByVal value As String)
            ' Provide implementation.
        End Set
    End Property
End Class
' </Snippet1>
