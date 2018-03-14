Imports System
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Public Shared Sub Main()
     'Creates an exception with an error message.
     Dim myException As New Exception("This is an exception test")
        
     'Creates an ErrorEventArgs with the exception.
     Dim myErrorEventArgs As New ErrorEventArgs(myException)
        
     'Extracts the exception from the ErrorEventArgs and display it.
     Dim myReturnedException As Exception = myErrorEventArgs.GetException()
     MessageBox.Show("The returned exception is: " _
        + myReturnedException.Message)
 End Sub
' </Snippet1>
End Class
