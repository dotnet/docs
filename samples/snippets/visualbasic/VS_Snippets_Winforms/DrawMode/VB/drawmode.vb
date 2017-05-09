' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private myTabRect As Rectangle

    Public Sub New()
        tabControl1 = New TabControl()
        Dim tabPage1 As New TabPage()

        ' Sets the tabs to be drawn by the parent window Form1.
        ' OwnerDrawFixed allows access to DrawItem. 
        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

        tabControl1.Controls.Add(tabPage1)
        tabControl1.Location = New Point(25, 25)
        tabControl1.Size = New Size(250, 250)

        tabPage1.TabIndex = 0

        myTabRect = tabControl1.GetTabRect(0)

        ClientSize = New Size(300, 300)
        Controls.Add(tabControl1)

        AddHandler tabControl1.DrawItem, AddressOf OnDrawItem
    End Sub

    Private Sub OnDrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        Dim g As Graphics = e.Graphics
        Dim p As New Pen(Color.Blue)
        g.DrawRectangle(p, myTabRect)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>