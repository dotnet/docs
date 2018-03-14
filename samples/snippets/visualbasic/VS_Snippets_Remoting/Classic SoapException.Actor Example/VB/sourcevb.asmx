'<Snippet2>
<%@ WebService Language="VB" Class="Math"%>
Imports System.Web.Services
Imports System

Public Class Math
    Inherits WebService

    <WebMethod()> _
    Public Function Divide(dividend As Integer, divisor As Integer) As Single
        If divisor = 0 Then
            Throw New DivideByZeroException()
        End If 
        Return Convert.ToSingle(dividend / divisor)
    End Function 'Divide
End Class  'Math
'</Snippet2>

