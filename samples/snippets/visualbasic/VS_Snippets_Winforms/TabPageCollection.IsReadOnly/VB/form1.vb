' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        Dim tabControl1 As New TabControl()
        Dim tabPage1 As New TabPage()
        Dim tabPage2 As New TabPage()
        Dim label1 As New Label()

        ' Determines if the tabControl1 controls collection is read-only.
        If tabControl1.TabPages.IsReadOnly = True Then
            label1.Text = "The tabControl1 controls collection is read-only."
        Else
            label1.Text = "The tabControl1 controls collection is not read-only."
        End If
        tabControl1.TabPages.AddRange(New TabPage() {tabPage1, tabPage2})
        tabControl1.Location = New Point(25, 75)
        tabControl1.Size = New Size(250, 200)

        label1.Location = New Point(25, 25)
        label1.Size = New Size(250, 25)

        Me.ClientSize = New Size(300, 300)
        Me.Controls.AddRange(New Control() {tabControl1, label1})
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>