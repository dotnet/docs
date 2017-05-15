Option Explicit
Option Strict

Imports System
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    ' <Snippet1>
    ' Class level declaration.
    ' Create a BooleanSwitch for data. 
    Private Shared dataSwitch As New BooleanSwitch("Data", "DataAccess module")
    
    
    Public Shared Sub MyMethod(location As String)
        ' Insert code here to handle processing.
        If dataSwitch.Enabled Then
            Console.WriteLine(("Error happened at " + location))
        End If
    End Sub 'MyMethod
    
    ' Entry point which delegates to C-style main function.
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
     
    Overloads Public Shared Sub Main(args() As String)
        ' Run the method which writes an error message specifying the location of the error.
        MyMethod("in Main")
    End Sub 'Main
    ' </Snippet1>
End Class 'Form1 
