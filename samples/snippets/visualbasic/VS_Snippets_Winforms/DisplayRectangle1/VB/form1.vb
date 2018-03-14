' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private myTabRect As Rectangle
   
   Public Sub New()
      Dim tabControl1 As New TabControl()
      Dim tabPage1 As New TabPage()
      
      tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
      tabControl1.Appearance = TabAppearance.Buttons
      tabControl1.Location = New Point(25, 25)
      tabControl1.Controls.Add(tabPage1)
      Controls.Add(tabControl1)
      
      ' Gets a Rectangle that represents the tab page display area of tabControl1.
      myTabRect = tabControl1.DisplayRectangle
      
      myTabRect.Inflate(1, 1)
      AddHandler tabControl1.DrawItem, AddressOf DrawOnTabPage
   End Sub
   
   Private Sub DrawOnTabPage(sender As Object, e As DrawItemEventArgs)
      Dim g As Graphics = e.Graphics
      Dim p As New Pen(Color.Blue)
      g.DrawRectangle(p, myTabRect)
   End Sub
   
   Shared Sub Main()
      Application.Run(New Form1())
   End Sub
End Class
' </snippet1>