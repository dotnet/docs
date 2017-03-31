Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
    Private Sub Method1()
        ' <Snippet1>
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        ' </Snippet1>
    End Sub 'Method1
    ' <Snippet2>
    Private Sub MyPropertyCollection()
        ' Creates a new collection and assign it the properties for button1.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(button1)
        
        ' Displays each property in the collection in a text box.
        Dim myProperty As PropertyDescriptor
        For Each myProperty In  properties
            textBox1.Text &= myProperty.Name & ControlChars.Cr
        Next myProperty
    End Sub 'MyPropertyCollection 
    ' </Snippet2>
End Class 'Form1
