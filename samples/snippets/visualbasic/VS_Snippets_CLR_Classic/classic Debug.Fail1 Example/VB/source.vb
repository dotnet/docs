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
    End Enum 'MyOption
    Protected option1 As MyOption
    Protected result As Double
    Protected value As Double
    Protected newValue As Double
    
    Protected Sub Method()
        Try
        ' <Snippet1>
        Catch e As Exception
            Debug.Fail("Invalid value: " + value.ToString(), "Resetting value to newValue.")
            value = newValue
        End Try
        ' </Snippet1>
        ' <Snippet2>
        Select Case option1
            Case MyOption.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Debug.Fail("Unknown Option " & option1, "Result set to 1.0")
                result = 1.0
        End Select
        ' </Snippet2>
    End Sub 'Method
End Class 'Form1 
