Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Resources


Namespace MyCursors

   Public Class MyCursor
      Inherits System.Windows.Forms.Form
      
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents myButton As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub
      
      
      
' <snippet1>
Private Sub SetCursor()
   ' Display an OpenFileDialog so the user can select a Cursor.
   Dim openFileDialog1 As New OpenFileDialog()
   openFileDialog1.Filter = "Cursor Files|*.cur"
   openFileDialog1.Title = "Select a Cursor File"
   openFileDialog1.ShowDialog()
         
   ' If a .cur file was selected, open it.
   If openFileDialog1.FileName <> "" Then
      ' Assign the cursor in the stream to the form's Cursor property.
      Me.Cursor = New Cursor(openFileDialog1.OpenFile())
   End If
End Sub     
' </snippet1>
      
' <snippet2>
Private Sub myButton_Click(sender As Object, e As System.EventArgs) Handles myButton.Click
   ' Call the CursorFromResource method and 
   ' display the embedded cursor resource. 
   Me.Cursor = CursorFromResource(GetType(MyCursors.MyCursor), "MyWaitCursor.cur")
End Sub 'myButton_Click
      
Private Function CursorFromResource(type As Type, resource As String) As Cursor
   ' Create a cursor from the resource.
   Try
      Return New Cursor(type, resource)
        
   ' If the cursor cannot be created, message the user.
   Catch ex As Exception
      MessageBox.Show(ex.ToString())
      Return Nothing
   End Try
End Function
' </snippet2>
      
' <snippet3>
Private Sub myButton_MouseEnter(sender As Object, e As System.EventArgs) Handles myButton.MouseEnter
   ' Hide the cursor when the mouse pointer enters the button.
   Cursor.Hide()
End Sub 'myButton_MouseEnter
      
      
Private Sub myButton_MouseLeave(sender As Object, e As System.EventArgs) Handles myButton.MouseLeave
   ' Show the cursor when the mouse pointer leaves the button.
   Cursor.Show()
End Sub 'myButton_MouseLeave
      
' </snippet3>
      

      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.myButton = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(104, 192)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' myButton
         ' 
         Me.myButton.Location = New System.Drawing.Point(40, 32)
         Me.myButton.Name = "myButton"
         Me.myButton.TabIndex = 1
         Me.myButton.Text = "myButton"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myButton, Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub
       
      Shared Sub Main() 
         Application.Run(New MyCursor())
      End Sub
      
      
      Private Sub button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         Me.SetCursor()
      End Sub

   End Class 'MyCursor 
End Namespace 'MyCursors 