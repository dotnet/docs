Imports System


Public Class Sample
    
    
    Public Sub sampleFunction()
        Dim math As New myMath()
        Dim Num1 As New myNum()
        Dim Num2 As New myNum()
' <Snippet1>
' Set the URL property to a different Web server than that described in the
' service description.
math.Url = "http://www.contoso.com/math.asmx"
Dim total As Integer = math.Add(Convert.ToInt32(Num1.Text), _
                                 Convert.ToInt32(Num2.Text))

' </Snippet1>

    End Sub
End Class

' Class added so sample will compile
Public Class myMath
    Public Url As String
    
    Public Function Add(a As Integer, b As Integer) As Integer
        Return 0
    End Function
End Class

' Structure added so sample will compile
Public Structure myNum
    Public Text As String
End Structure
