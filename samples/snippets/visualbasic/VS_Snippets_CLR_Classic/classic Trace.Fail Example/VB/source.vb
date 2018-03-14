Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Public Enum OptionConsts
        First
        Second
    End Enum 'Option
    
    Protected result As Double
    
    Public Sub Method(option1 As OptionConsts)
        Try
            ' try something here
        ' <Snippet1>
        Catch
            Trace.Fail("Unknown Option " + option1 + ", using the default.")
        End Try
        ' </Snippet1>
        ' <Snippet2>
        Select Case option1
            Case OptionConsts.First
                result = 1.0
            
            ' Insert additional cases.
            Case Else
                Trace.Fail(("Unknown Option " & option1))
                result = 1.0
        End Select
        ' </Snippet2>
    End Sub 'Method
End Class 'Form1 
