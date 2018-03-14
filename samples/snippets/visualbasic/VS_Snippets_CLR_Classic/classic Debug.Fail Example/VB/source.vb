Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    
    Protected Enum MyOption
        First
        Second
    End Enum
    
    Protected myOption1 As MyOption
    
    Protected result As Double
    
    
    Protected Sub Method()
        Try
        '
        ' <Snippet1>
        Catch e As Exception
            Debug.Fail("Unknown Option " + myOption1 + ", using the default.")
        End Try
        ' </Snippet1>
        ' <Snippet2>
        Select Case myOption1
            Case MyOption.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Debug.Fail(("Unknown Option " & myOption1.ToString))
                result = 1.0
        End Select
        ' </Snippet2>
    End Sub 'Method
End Class 'Form1 
