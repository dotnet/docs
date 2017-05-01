' <snippet1>
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage

    Public Sub MyTabs()

        ' Invokes the TabControl() constructor to create the tabControl1 object.
        Me.tabControl1 = New System.Windows.Forms.TabControl()

        ' Creates a new tab page and adds it to the tab control.
        Me.tabPage1 = New TabPage()

        Me.tabControl1.TabPages.Add(tabPage1)

        ' Adds the tab control to the form.	
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