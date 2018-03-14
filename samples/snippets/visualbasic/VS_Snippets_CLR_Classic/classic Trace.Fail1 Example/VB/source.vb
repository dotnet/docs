Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
#Const TRACE=True

Public Class Form1
    Inherits Form
    
    Public Enum OptionConsts
        First
        Second
    End Enum 'Option

    Protected result As Double
    
    
    Public Sub Method(option1 As OptionConsts, userInput As string)
        Dim value As Integer = 0
        Dim newValue As Integer = 1
        Try
            value = Int32.Parse(userInput)
        ' <Snippet1>
        Catch
            Trace.Fail("Invalid value: " & value.ToString(), _
                "Resetting value to newValue.")
            value = newValue
        End Try
        ' </Snippet1>
        ' <Snippet2>
        Select Case option1
            Case OptionConsts.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Trace.Fail("Unsupported option " & option1, "Result set to 1.0")
                result = 1.0
        End Select
        ' </Snippet2>
    End Sub 'Method

    Public Shared Sub Main()
        Dim myForm as Form1 = new Form1()
        myForm.Method(OptionConsts.Second, "not an integer string")
    End Sub

End Class 'Form1 
