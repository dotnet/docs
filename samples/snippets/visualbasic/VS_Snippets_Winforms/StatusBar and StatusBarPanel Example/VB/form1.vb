Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub
   
   Friend WithEvents Button1 As System.Windows.Forms.Button

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.Container

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(128, 88)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(72, 24)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Button1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   '<snippet1>
   Private Sub CreateMyStatusBar()
      ' Create a StatusBar control.
      Dim statusBar1 As New StatusBar()

      ' Create two StatusBarPanel objects to display in the StatusBar.
      Dim panel1 As New StatusBarPanel()
      Dim panel2 As New StatusBarPanel()

      ' Display the first panel with a sunken border style.
      panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken

      ' Initialize the text of the panel.
      panel1.Text = "Ready..."

      ' Set the AutoSize property to use all remaining space on the StatusBar.
      panel1.AutoSize = StatusBarPanelAutoSize.Spring
      
      ' Display the second panel with a raised border style.
      panel2.BorderStyle = StatusBarPanelBorderStyle.Raised
      
      ' Create ToolTip text that displays the time the application was started.
      panel2.ToolTipText = "Started: " & System.DateTime.Now.ToShortTimeString()

      ' Set the text of the panel to the current date.
      panel2.Text = System.DateTime.Today.ToLongDateString()

      ' Set the AutoSize property to size the panel to the size of the contents.
      panel2.AutoSize = StatusBarPanelAutoSize.Contents

      ' Display panels in the StatusBar control.
      statusBar1.ShowPanels = True

      ' Add both panels to the StatusBarPanelCollection of the StatusBar.			
      statusBar1.Panels.Add(panel1)
      statusBar1.Panels.Add(panel2)

      ' Add the StatusBar to the form.
      Me.Controls.Add(statusBar1)
   End Sub
   '</snippet1>

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      CreateMyStatusBar()
   End Sub

   Public Shared Sub Main()
      Application.Run(new Form1())
   End Sub

End Class
