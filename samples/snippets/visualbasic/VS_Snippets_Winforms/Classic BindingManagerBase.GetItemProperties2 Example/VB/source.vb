Option Explicit
Option Strict

Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub PrintPropertyDescriptions(b As BindingManagerBase)
        Console.WriteLine("Printing Property Descriptions")
        Dim ps As PropertyDescriptorCollection = b.GetItemProperties()
        Dim i As Integer
        For i = 0 To ps.Count - 1
            Console.WriteLine((ControlChars.Tab & ps(i).Name & ControlChars.Tab & ps(i).PropertyType.ToString))
        Next i
    End Sub 'PrintPropertyDescriptions
    ' </Snippet1>
End Class 'Form1 
