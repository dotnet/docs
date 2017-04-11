' System.Windows.Forms.Control.ContextMenu
' System.Windows.Forms.Control.ContextMenuChanged
' System.Windows.Forms.Control.CreateGraphics

' The following program demonstrates the 'ContextMenu' property, 'ContextMenuChanged'
' event handler and 'CreateGraphics' method of 'Control' class.
' It displays the 'TextBox' and 'Button' controls on the form. When mouse is clicked inside
' the 'TextBox' control, an instance of 'ContextMenu' is created and assigned to 'TextBox'
' control by using 'ContextMenu' property. The shortcut menu pops-up when right button of
' mouse is clicked inside the 'TextBox' control. When the 'Button' is clicked, an
' instance of 'Graphics' class is obtained by calling 'CreateGraphics' method and draws an
' ellipse inside the 'TextBox' control.

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MyApplication

   Public Class MyForm
      Inherits Form
      Private myTextBox As System.Windows.Forms.TextBox
      Private components As System.ComponentModel.Container = Nothing
      Private myLabel As System.Windows.Forms.Label
      Private WithEvents myButton As System.Windows.Forms.Button
      
      Public Sub New()
         InitializeComponent()
         AddClickHandler()
         AddContextMenuChangedHandler()
      End Sub 'New
      
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      
      Private Sub InitializeComponent()
         Me.myButton = New System.Windows.Forms.Button()
         Me.myLabel = New System.Windows.Forms.Label()
         Me.myTextBox = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         '
         ' myButton
         '
         Me.myButton.Location = New System.Drawing.Point(48, 232)
         Me.myButton.Name = "myButton"
         Me.myButton.Size = New System.Drawing.Size(96, 23)
         Me.myButton.TabIndex = 2
         Me.myButton.Text = "CreateGraphics"
         '
         ' myLabel
         '
         Me.myLabel.Location = New System.Drawing.Point(24, 16)
         Me.myLabel.Name = "myLabel"
         Me.myLabel.Size = New System.Drawing.Size(256, 40)
         Me.myLabel.TabIndex = 1
         Me.myLabel.Text = "Click inside the TextBox to set the ContextMenu and then click the" + _
                 "right mouse button inside the TextBox to pop up the ContextMenu."
         '
         ' myTextBox
         '
         Me.myTextBox.Location = New System.Drawing.Point(16, 80)
         Me.myTextBox.Multiline = True
         Me.myTextBox.Name = "myTextBox"
         Me.myTextBox.Size = New System.Drawing.Size(240, 112)
         Me.myTextBox.TabIndex = 0
         Me.myTextBox.Text = "Welcome to .NET"
         '
         ' MyForm
         '
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myButton, _
                  Me.myLabel, Me.myTextBox})
         Me.Name = "MyForm"
         Me.Text = "ContextMenu Example"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
' <Snippet1>
      Private Sub AddClickHandler()
         AddHandler Me.myTextBox.Click, AddressOf TextBox_Click
      End Sub 'AddClickHandler
      
      Private Sub TextBox_Click(sender As Object, e As EventArgs)
         Dim myMenuItems(1) As MenuItem
         myMenuItems(0) = New MenuItem("New", New EventHandler(AddressOf MenuItem_New))
         myMenuItems(1) = New MenuItem("Open", New EventHandler(AddressOf MenuItem_Open))
         Me.myTextBox.ContextMenu = New ContextMenu(myMenuItems)
      End Sub 'TextBox_Click
      
      Private Sub MenuItem_New(sender As Object, e As EventArgs)
         MessageBox.Show("New MenuItem is selected from TextBox's shortcut menu.")
      End Sub 'MenuItem_New
      
      Private Sub MenuItem_Open(sender As Object, e As EventArgs)
         MessageBox.Show("Open MenuItem is selected from TextBox's shortcut menu.")
      End Sub 'MenuItem_Open
' </Snippet1>
' <Snippet2>
      Private Sub AddContextMenuChangedHandler()
         AddHandler Me.myTextBox.ContextMenuChanged, AddressOf TextBox_ContextMenuChanged
      End Sub 'AddContextMenuChangedHandler

      Private Sub TextBox_ContextMenuChanged(sender As Object, e As EventArgs)
         MessageBox.Show("Shortcut menu of TextBox is changed.")
      End Sub 'TextBox_ContextMenuChanged

' </Snippet2>
      Private Sub CreateGraphicsButton_Click(sender As Object, e As System.EventArgs) Handles myButton.Click

' <Snippet3>
         Dim myGraphics As Graphics = myTextBox.CreateGraphics()
         myGraphics.DrawEllipse(new Pen(Color.Black, 3), 0F, 0F, 230F, 105F)
         myGraphics.FillEllipse(Brushes.Goldenrod, 0F, 0F, 230F, 105F)
' </Snippet3>
      
      End Sub 'CreateGraphicsButton_Click

   <STAThread()>  _
      Shared Sub Main()
         Application.Run(New MyForm())
      End Sub 'Main
   End Class 'MyForm
End Namespace 'MyApplication