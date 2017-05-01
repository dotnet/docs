' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl

    ' Declares tabPage1 as a TabPage type.
    Private tabPage1 As System.Windows.Forms.TabPage

    Private Sub MyTabs()
        Me.tabControl1 = New TabControl()

        ' Invokes the TabPage() constructor to create the tabPage1.
        Me.tabPage1 = New System.Windows.Forms.TabPage()

        Me.tabControl1.Controls.AddRange(New Control() {Me.tabPage1})
        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)

        Me.ClientSize = New Size(300, 300)
        Me.Controls.AddRange(New Control() {Me.tabControl1})
    End Sub

    Public Sub New()
        MyTabs()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>