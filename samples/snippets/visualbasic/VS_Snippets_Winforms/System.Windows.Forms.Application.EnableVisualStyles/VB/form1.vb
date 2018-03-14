'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace VStyles
    
    ' Summary description for Form1.
    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private button1 As System.Windows.Forms.Button

        <System.STAThread()> _
        Public Shared Sub Main()

            System.Windows.Forms.Application.EnableVisualStyles()
            System.Windows.Forms.Application.Run(New Form1)
        End Sub 'Main

        Public Sub New()

            Me.button1 = New System.Windows.Forms.Button()
            Me.button1.Location = New System.Drawing.Point(24, 16)
            Me.button1.Size = New System.Drawing.Size(120, 100)
            Me.button1.FlatStyle = FlatStyle.System
            Me.button1.Text = "I am themed."

            ' Sets up how the form should be displayed and adds the controls to the form.
            Me.ClientSize = New System.Drawing.Size(300, 286)
            Me.Controls.Add(Me.button1)

            Me.Text = "Application.EnableVisualStyles Example"
        End Sub 'New 

    End Class 'Form1
End Namespace 'VStyles
'</Snippet1>