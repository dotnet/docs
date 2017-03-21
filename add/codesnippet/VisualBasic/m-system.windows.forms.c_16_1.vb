' This is a custom TextBox control that overrides the OnClick method
' to allow one-click selection of the text in the text box.

Public Class SingleClickTextBox
    Inherits TextBox

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        Me.SelectAll()
        MyBase.OnClick(e)
    End Sub


End Class