'<snippet0>
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()

        Dim panel As New FlowLayoutPanel()

        Dim tabTextBox1 As New TabTextBox()
        tabTextBox1.Text = "TabTextBox"
        panel.Controls.Add(tabTextBox1)

        Dim textBox1 As New TextBox()
        textBox1.Text = "Normal TextBox"
        panel.Controls.Add(textBox1)

        Me.Controls.Add(panel)

    End Sub

End Class

Class TabTextBox
    Inherits TextBox

    Protected Overrides Function IsInputKey( _
        ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData = Keys.Tab Then
            Return True
        Else
            Return MyBase.IsInputKey(keyData)
        End If

    End Function

    Protected Overrides Sub OnKeyDown( _
        ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyData = Keys.Tab Then
            Me.SelectedText = "    "
        Else
            MyBase.OnKeyDown(e)
        End If

    End Sub

End Class
'</snippet0>