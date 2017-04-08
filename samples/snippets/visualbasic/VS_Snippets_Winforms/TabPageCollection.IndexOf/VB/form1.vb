' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage("myTabPage")

        Me.tabControl1.Controls.Add(tabPage1)
        Me.tabControl1.ShowToolTips = True
        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)

        ' Gets the tabPage1 TabIndex value from the tabControl1 controls collection.
        ' Converts the tabPage1 TabIndex value to a string.

        Me.tabPage1.ToolTipText = "TabIndex = " + tabControl1.TabPages.IndexOf(tabPage1).ToString()

        Me.ClientSize = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>