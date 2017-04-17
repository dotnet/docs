' <Snippet1>
<%@ WebService Language="VB" Class="Util"%>

Imports System.Web.Services

Public Class Util
    Inherits WebService
    
    <WebMethod(Description := "Application Hit Counter", _
        EnableSession := False)> _
    Public Function HitCounter() As Integer
        
        If Application("HitCounter") Is Nothing Then
            Application("HitCounter") = 1
        Else
            Application("HitCounter") = CInt(Application("HitCounter")) + 1
        End If
        Return CInt(Application("HitCounter"))
    End Function
End Class
    
' </Snippet1>
