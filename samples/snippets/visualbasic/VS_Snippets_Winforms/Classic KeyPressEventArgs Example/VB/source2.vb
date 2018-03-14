Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    Public textBox1 As TextBox
    ' <Snippet2>
    Private myKeyPressHandler As New myKeyPressClass()
    
    Public Sub New()
        InitializeComponent()
        
        AddHandler textBox1.KeyPress, AddressOf myKeyPressHandler.myKeyCounter
    End Sub 'New
    
    ' </Snippet2>
    Private Sub InitializeComponent()
    End Sub 'InitializeComponent
    
    Public Class myKeyPressClass
        
        Friend Sub myKeyCounter(sender As Object, ex As KeyPressEventArgs)
        End Sub 'myKeyCounter
    End Class 'myKeyPressClass
End Class 'Form1 
