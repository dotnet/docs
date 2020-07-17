Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        '<CreateControl>
        Dim label1 As New Label With {.Text = "&First Name",
                                      .Location = New Point(10, 10),
                                      .TabIndex = 10}

        Dim field1 As New TextBox With {.Location = New Point(label1.Location.X,
                                                              label1.Bounds.Bottom + Padding.Top),
                                        .TabIndex = 11}

        Controls.Add(label1)
        Controls.Add(field1)
        '</CreateControl>
    End Sub
End Class