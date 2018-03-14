' System.Windows.Forms.Control.VisibleChanged

' The following program demonstrates 'VisibleChanged' event for the 'Control' class.
' The 'VisibleChanged' event is raised when the 'Visible' property value of
' 'Label' control has changed.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Namespace MyControlExample

   Public Class MyForm
      Inherits Form
      Private myLabel As Label
      Private myButton As Button
      Private components As Container = Nothing

      Public Sub New()
         InitializeComponent()
      End Sub 'New

      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose

      Private Sub InitializeComponent()
         Me.myLabel = New Label()
         Me.myButton = New Button()
         Me.SuspendLayout()

         '
         ' myLabel
         '
         Me.myLabel.Location = New System.Drawing.Point(24, 8)
         Me.myLabel.Name = "myLabel"
         Me.myLabel.Size = New System.Drawing.Size(240, 40)
         Me.myLabel.Text += "Welcome to .NET."

         '
         ' myButton
         '
         Me.myButton.Location = New System.Drawing.Point(54, 50)
         Me.myButton.Name = "myLabel"
         Me.myButton.Size = New System.Drawing.Size(100, 40)
         Me.myButton.TabIndex = 0
         Me.myButton.Text = "Hide Label"
         AddHandler Me.myButton.Click, AddressOf Button_HideLabel

         '
         ' MyForm
         '
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.Add(myLabel)
         Me.Controls.Add(myButton)

         Me.Name = "MyForm"
         Me.Text = "VisibleChanged example"
         Me.ResumeLayout(False)
         AddVisibleChangedEventHandler()
      End Sub 'InitializeComponent

      <STAThread()> _
      Shared Sub Main()
         Application.Run(New MyForm())
      End Sub 'Main


' <Snippet1>
      Private Sub Button_HideLabel(ByVal sender As Object, ByVal e As EventArgs)
         myLabel.Visible = False
      End Sub 'Button_HideLabel


      Private Sub AddVisibleChangedEventHandler()
         AddHandler myLabel.VisibleChanged, AddressOf Label_VisibleChanged
      End Sub 'AddVisibleChangedEventHandler


      Private Sub Label_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
         MessageBox.Show("Visible change event raised!!!")
      End Sub 'Label_VisibleChanged
' </Snippet1>
   End Class 'MyForm 
End Namespace 'MyControlExample