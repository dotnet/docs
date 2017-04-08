Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports System.Runtime.CompilerServices

<Assembly: AssemblyCompany("Microsoft")>
<Assembly: AssemblyProduct("Test")>
<Assembly: AssemblyVersion("1.0.*")>

Namespace CodeExamples
   Public Class AboutDialog
      Inherits System.Windows.Forms.Form
      Private buttonOK As System.Windows.Forms.Button
      Private labelVersionInfo As System.Windows.Forms.Label
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      Private Sub InitializeComponent()
         Me.labelVersionInfo = New System.Windows.Forms.Label()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' labelVersionInfo
         ' 
         Me.labelVersionInfo.Location = New System.Drawing.Point(8, 8)
         Me.labelVersionInfo.Name = "labelVersionInfo"
         Me.labelVersionInfo.Size = New System.Drawing.Size(360, 23)
         Me.labelVersionInfo.TabIndex = 0
         Me.labelVersionInfo.Text = "label1"
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.Location = New System.Drawing.Point(296, 64)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.TabIndex = 3
         Me.buttonOK.Text = "&OK"
         ' 
         ' AboutDialog
         ' 
         Me.ClientSize = New System.Drawing.Size(392, 109)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.buttonOK, Me.labelVersionInfo})
         Me.Name = "AboutDialog"
         Me.Text = "About"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
     Shared Sub Main()
         Application.Run(New AboutDialog())
      End Sub 'Main
      
      
' <snippet1>
Private Sub AboutDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   ' Display the application information in the label.
   Me.labelVersionInfo.Text = _
      Me.CompanyName + "  " + _
      Me.ProductName + "  Version: " + _
      Me.ProductVersion
   End Sub
' </snippet1>


   End Class 'AboutDialog
End Namespace 'ControlMembers2
