Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace ISelectionServiceExample
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents componentClass1 As ISelectionServiceExample.ComponentClass

      Private components As System.ComponentModel.Container = Nothing

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


#Region "Windows Form Designer generated code"
      ' Required method for Designer support - do not modify
      ' the contents of this method with the code editor.
      Private Sub InitializeComponent()
         Me.componentClass1 = New ISelectionServiceExample.ComponentClass()
         Me.SuspendLayout()

         ' componentClass1
         Me.componentClass1.Location = New System.Drawing.Point(80, 32)
         Me.componentClass1.Name = "componentClass1"
         Me.componentClass1.Size = New System.Drawing.Size(608, 296)
         Me.componentClass1.TabIndex = 0

         ' Form1
         Me.ClientSize = New System.Drawing.Size(480, 285)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.componentClass1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
#End Region

      Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      End Sub 'Form1_Load

      ' The main entry point for the application.
      Public Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main

      Private Sub componentClass1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles componentClass1.Load
      End Sub 'componentClass1_Load
   End Class 'Form1 
End Namespace 'ISelectionServiceExample
