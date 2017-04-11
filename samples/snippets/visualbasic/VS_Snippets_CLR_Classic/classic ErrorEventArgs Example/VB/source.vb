Imports System
Imports System.Data
Imports System.IO
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    ' <Snippet1>
    Overloads Public Shared Sub Main(args() As String)
        ' Creates an exception with an error message.
        Dim myException As New Exception("This is an exception test")
        
        ' Creates an ErrorEventArgs with the exception.
        Dim myErrorEventArgs As New ErrorEventArgs(myException)
        
        ' Extracts the exception from the ErrorEventArgs and display it.
        Dim myReturnedException As Exception = myErrorEventArgs.GetException()
        MessageBox.Show(("The returned exception is: " & myReturnedException.Message))
    End Sub 'Main
    ' </Snippet1>
End Class 'Form1 

