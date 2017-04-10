' <snippet1>
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage

    Public Sub MyTabs()
        Me.tabControl1 = New TabControl()

        ' Invokes the TabPage() constructor to create the tabPage1.
        Me.tabPage1 = New System.Windows.Forms.TabPage()

        Me.tabControl1.Controls.Add(tabPage1)
        Me.Controls.Add(tabControl1)
    End Sub

    Public Sub New()
        MyTabs()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>