Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Namespace ControlProperties
   
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private imageList1 As System.Windows.Forms.ImageList
      Private WithEvents button2 As System.Windows.Forms.Button
      Private components As System.ComponentModel.IContainer
      
      
      Public Sub New()
         InitializeComponent()
         AddMyGroupBox()

      End Sub 'New

      
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As New System.Resources.ResourceManager(GetType(Form1))
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.button2 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' imageList1
         ' 
         Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
         Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
         Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(40, 232)
         Me.button2.Name = "button2"
         Me.button2.TabIndex = 0
         Me.button2.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.BackColor = System.Drawing.Color.FromArgb(CType(0, System.Byte), CType(64, System.Byte), CType(0, System.Byte))
         Me.ClientSize = New System.Drawing.Size(408, 405)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       

'<snippet3>
' Add a button to a form and set some of its common properties.
Private Sub AddMyButton()
   ' Create a button and add it to the form.
   Dim button1 As New Button()
   
   ' Anchor the button to the bottom right corner of the form
   button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
   
   ' Assign a background image.
   button1.BackgroundImage = imageList1.Images(0)

   ' Specify the layout style of the background image. Tile is the default.
   button1.BackgroundImageLayout = ImageLayout.Center
   
   ' Make the button the same size as the image.
   button1.Size = button1.BackgroundImage.Size
   
   ' Set the button's TabIndex and TabStop properties.
   button1.TabIndex = 1
   button1.TabStop = True

   ' Add a delegate to handle the Click event.
   AddHandler button1.Click, AddressOf Me.button1_Click
   
   ' Add the button to the form.
   Me.Controls.Add(button1)
End Sub
' </snippet3>


'<snippet2>
' Add a GroupBox to a form and set some of its common properties.
Private Sub AddMyGroupBox()
   ' Create a GroupBox and add a TextBox to it.
   Dim groupBox1 As New GroupBox()
   Dim textBox1 As New TextBox()
   textBox1.Location = New Point(15, 15)
   groupBox1.Controls.Add(textBox1)
   
   ' Set the Text and Dock properties of the GroupBox.
   groupBox1.Text = "MyGroupBox"
   groupBox1.Dock = DockStyle.Top
   
   ' Disable the GroupBox (which disables all its child controls)
   groupBox1.Enabled = False
   
   ' Add the Groupbox to the form.
   Me.Controls.Add(groupBox1)
End Sub
' </snippet2>
      

' <snippet1>
' Reset all the controls to the user's default Control color. 
Private Sub ResetAllControlsBackColor(control As Control)
   control.BackColor = SystemColors.Control
   control.ForeColor = SystemColors.ControlText
   If control.HasChildren Then
      ' Recursively call this method for each child control.
      Dim childControl As Control
      For Each childControl In  control.Controls
         ResetAllControlsBackColor(childControl)
      Next childControl
   End If
End Sub
' </snippet1>


      
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      
      Private Sub button1_Click(sender As Object, e As System.EventArgs)
         Me.ResetAllControlsBackColor(Me)
      End Sub 'button1_Click
      
      
      Private Sub button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         Me.AddMyButton()
      End Sub 'button2_Click


   End Class 'Form1
End Namespace 'ControlProperties