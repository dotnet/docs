' <Snippet2>
<%@ WebService Language="VB" Class="MyMath"%>
Imports System.Web.Services
Imports System

<WebService(Namespace:="http://www.contoso.com/")> _
Public Class MyMath
    <WebMethod()> _
    Public Function Add(num1 As Integer, num2 As Integer) As Integer
        Return num1 + num2
    End Function 'Add
End Class 'Math
' </Snippet2>

