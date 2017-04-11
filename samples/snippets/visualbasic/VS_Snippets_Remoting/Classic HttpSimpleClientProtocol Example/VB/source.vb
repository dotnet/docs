' <Snippet1>
Imports System.Web.Services
Imports System

Public Class Math
    <WebMethod()> _
    Public Function Add(num1 As Integer, num2 As Integer)As Integer
    
        Return num1 + num2
    End Function
    
End Class

' </Snippet1>
