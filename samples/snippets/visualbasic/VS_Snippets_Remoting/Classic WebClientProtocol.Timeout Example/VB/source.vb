Imports System

Public Class Sample    
    
    Public Sub sampleFunction()
        Dim math As New myMath()
        
' <Snippet1>
math.Timeout = 15000

' </Snippet1>
    End Sub
End Class

' Structure added so sample will compile
Public Structure myMath
    Public Timeout As Integer
End Structure
