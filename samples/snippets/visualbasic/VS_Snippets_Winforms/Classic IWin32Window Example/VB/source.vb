Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected label1 As Label
    
    
' <Snippet1>
    Public Sub New()
        InitializeComponent()
        
        Me.label1.Text = Me.Handle.ToString()
    End Sub    
    
' </Snippet1>

    Protected Sub InitializeComponent()
    End Sub
End Class
