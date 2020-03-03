' <Snippet1>
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Load

        Dim comboBox As New ComboBox
        Dim daysOfWeek As String() = _
            New String() {"Monday", "Tuesday", "Wednesday", _
                          "Thursday", "Friday", "Saturday", _
                          "Sunday"}

        With comboBox
            .DataSource = daysOfWeek
            .Location = New System.Drawing.Point(12, 12)
            .Name = "comboBox"
            .Size = New System.Drawing.Size(166, 21)
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        Me.Controls.Add(comboBox)
    End Sub

End Class
' </Snippet1>
