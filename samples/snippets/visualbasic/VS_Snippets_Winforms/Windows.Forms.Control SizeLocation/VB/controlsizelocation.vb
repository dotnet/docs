Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Namespace ControlMembers
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private Withevents button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.Container = Nothing
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
         Me.button1.Location = New System.Drawing.Point(104, 104)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      Shared Sub Main() 
         Application.Run(New Form1())
      End Sub 'Main
      

      
' <snippet1>
' Create three buttons and place them on a form using 
' several size and location related properties. 
Private Sub AddOKCancelButtons()
   ' Set the button size and location using 
      ' the Size and Location properties. 
   Dim buttonOK As New Button()
   buttonOK.Location = New Point(136, 248)
   buttonOK.Size = New Size(75, 25)
   ' Set the Text property and make the 
   ' button the form's default button. 
   buttonOK.Text = "&OK"
   Me.AcceptButton = buttonOK
   
   ' Set the button size and location using the Top, 
   ' Left, Width, and Height properties. 
   Dim buttonCancel As New Button()
   buttonCancel.Top = buttonOK.Top
   buttonCancel.Left = buttonOK.Right + 5
   buttonCancel.Width = buttonOK.Width
   buttonCancel.Height = buttonOK.Height
   ' Set the Text property and make the 
   ' button the form's cancel button. 
   buttonCancel.Text = "&Cancel"
   Me.CancelButton = buttonCancel
   
   ' Set the button size and location using 
   ' the Bounds property. 
   Dim buttonHelp As New Button()
   buttonHelp.Bounds = New Rectangle(10, 10, 75, 25)
   ' Set the Text property of the button.
   buttonHelp.Text = "&Help"
   
   ' Add the buttons to the form.
   Me.Controls.AddRange(New Control() {buttonOK, buttonCancel, buttonHelp})
End Sub
' </snippet1>


      Private Sub button_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         'Dim ctrl As Control = CType(sender, Control)
         'MessageBox.Show("Top: " + ctrl.Top.ToString() + ControlChars.Cr + "Bottom: " + ctrl.Bottom.ToString() + ControlChars.Cr + "Left: " + ctrl.Left.ToString() + ControlChars.Cr + "Right: " + ctrl.Right.ToString() + ControlChars.Cr + "Width: " + ctrl.Width.ToString() + ControlChars.Cr + "Height: " + ctrl.Height.ToString() + ControlChars.Cr + "Size: " + ctrl.Size.ToString() + ControlChars.Cr + "Location: " + ctrl.Location.ToString(), "button1 Position", MessageBoxButtons.OKCancel)
         Me.AddOKCancelButtons()
      End Sub 'button_Click
   End Class 'Form1 
End Namespace 'ControlMembers 