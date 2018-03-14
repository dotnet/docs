
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace CursorStuff

   Public Class Form1
      Inherits System.Windows.Forms.Form

      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents button2 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub
      
      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.button2 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Cursor = System.Windows.Forms.Cursors.Default
         Me.button1.Location = New System.Drawing.Point(40, 184)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 2
         Me.button1.Text = "button1"
         ' 
         ' button2
         ' 
         Me.button2.Cursor = System.Windows.Forms.Cursors.Default
         Me.button2.Location = New System.Drawing.Point(56, 232)
         Me.button2.Name = "button2"
         Me.button2.TabIndex = 3
         Me.button2.Text = "button2"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button1})
         Me.Cursor = System.Windows.Forms.Cursors.Hand
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 
       
      Shared Sub Main() '
         Application.Run(New Form1())
      End Sub 
      
      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         MoveCursor()
      End Sub
      
' <snippet1>
Private Sub MoveCursor()
   ' Set the Current cursor, move the cursor's Position,
   ' and set its clipping rectangle to the form. 

   Me.Cursor = New Cursor(Cursor.Current.Handle)
   Cursor.Position = New Point(Cursor.Position.X - 50, Cursor.Position.Y - 50)
   Cursor.Clip = New Rectangle(Me.Location, Me.Size)
End Sub
' </snippet1>
      
' <snippet2>
Private Sub DrawCursorsOnForm(cursor As Cursor)
   ' If the form's cursor is not the Hand cursor and the 
   ' Current cursor is the Default, Draw the specified 
   ' cursor on the form in normal size and twice normal size. 
   If (Not Me.Cursor.Equals(Cursors.Hand)) And _
     Cursor.Current.Equals(Cursors.Default) Then

      ' Draw the cursor stretched.
      Dim graphics As Graphics = Me.CreateGraphics()
      Dim rectangle As New Rectangle(New Point(10, 10), _
        New Size(cursor.Size.Width * 2, cursor.Size.Height * 2))
      cursor.DrawStretched(graphics, rectangle)
     
      ' Draw the cursor in normal size.
      rectangle.Location = New Point(rectangle.Width + _
        rectangle.Location.X, rectangle.Height + rectangle.Location.Y)
      rectangle.Size = cursor.Size
      cursor.Draw(graphics, rectangle)

      ' Dispose of the cursor.
      cursor.Dispose()
   End If
End Sub
' </snippet2>
      
      Private Sub button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         DrawCursorsOnForm(New Cursor("c:\MyCursor.cur"))
      End Sub

   End Class 

End Namespace