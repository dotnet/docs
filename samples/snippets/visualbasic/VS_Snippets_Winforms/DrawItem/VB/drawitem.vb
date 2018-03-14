' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabArea As Rectangle
    Private tabTextArea As RectangleF

    Public Sub New()
        Dim tabControl1 As New TabControl()
        Dim tabPage1 As New TabPage()

        ' Allows access to the DrawItem event. 
        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

        tabControl1.SizeMode = TabSizeMode.Fixed
        tabControl1.Controls.Add(tabPage1)
        tabControl1.ItemSize = New Size(80, 30)
        tabControl1.Location = New Point(25, 25)
        tabControl1.Size = New Size(250, 250)
        tabPage1.TabIndex = 0
        ClientSize = New Size(300, 300)
        Controls.Add(tabControl1)

        tabArea = tabControl1.GetTabRect(0)
        tabTextArea = RectangleF.op_Implicit(tabControl1.GetTabRect(0))

        ' Binds the event handler DrawOnTab to the DrawItem event 
        ' through the DrawItemEventHandler delegate.
        AddHandler tabControl1.DrawItem, AddressOf DrawOnTab
    End Sub

    ' Declares the event handler DrawOnTab which is a method that
    ' draws a string and Rectangle on the tabPage1 tab.
    Private Sub DrawOnTab(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        Dim g As Graphics = e.Graphics
        Dim p As New Pen(Color.Blue)
        Dim font As New Font("Arial", 10.0F)
        Dim brush As New SolidBrush(Color.Red)

        g.DrawRectangle(p, tabArea)
        g.DrawString("tabPage1", font, brush, tabTextArea)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
