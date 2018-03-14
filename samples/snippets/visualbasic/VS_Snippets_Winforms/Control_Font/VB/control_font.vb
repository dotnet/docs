' System.Windows.Forms.Control.Font
' System.Windows.Forms.Control.FontChanged
' System.Windows.Forms.Control.Focused
' System.Windows.Forms.Control.Focus

' The following example demonstrates 'Font' & 'Focused' properties, 'Focus' 
' method and 'FontChanged' event of 'Control' class.
' A 'DateTimePicker' control and a 'Button' control are added to a form. The font 
' property of 'DateTimePicker' control is changed to the font selected by user 
' from 'FontDialog' control. An event handler function is attached
' with 'FontChanged' event of 'DateTimePicker' control which sets the focus
' on 'DateTimePicker' control.

Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class MyFormControl
   Inherits Form
   
   Private myDateTimePicker As DateTimePicker
   Public myButton As Button
   
   Public Sub New()
      myDateTimePicker = New DateTimePicker()
      myButton = New Button()
      myDateTimePicker.Location = New Point(48, 24)
      myDateTimePicker.Name = "myDateTimePicker"
      myButton.Location = New Point(50, 150)
      myButton.Name = "myButton"
      myButton.Size = New Size(200, 40)
      myButton.Text = "Change Font of Date Time Picker"
      AddHandler myButton.Click, AddressOf myButton_Click
      ClientSize = New Size(292, 273)
      Controls.AddRange(New Control() {myDateTimePicker, myButton})
      Text = "Control Example"
      AddEventHandler()
   End Sub 'New
   
   Shared Sub Main()
      Dim myForm As New MyFormControl()
      myForm.ShowDialog()
   End Sub 'Main

' <Snippet1>
   Private Sub myButton_Click(sender As Object, e As EventArgs)
      Dim myFontDialog As FontDialog
      myFontDialog = New FontDialog()
      
      If myFontDialog.ShowDialog() = DialogResult.OK Then
         ' Set the control's font.
         myDateTimePicker.Font = myFontDialog.Font
      End If
   End Sub
' </Snippet1>

' <Snippet2>
   Private Sub AddEventHandler()
      ' Add the event handler for 'FontChanged' event.
      AddHandler myDateTimePicker.FontChanged, AddressOf DateTimePicker_FontChanged
   End Sub 
   
   Private Sub DateTimePicker_FontChanged(sender As Object, e As EventArgs)
' <Snippet3>
' <Snippet4>
      If Not myDateTimePicker.Focused Then
         ' Set focus on 'DateTimePicker' control.
         myDateTimePicker.Focus()
      End If
' </Snippet4>
' </Snippet3>
   End Sub
' </Snippet2>


End Class 

