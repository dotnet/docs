' <Snippet1>
<%@ WebService Language="VB" Class="Util" %>
 
Imports System.Web.Services

Public Class Util
    Inherits WebService
    
    <WebMethod(True)> _
    Public Function SessionHitCounter() As Integer
        
        If Session("HitCounter") Is Nothing Then
            Session("HitCounter") = 1
        Else
            Session("HitCounter") = CInt(Session("HitCounter")) + 1
        End If
        Return CInt(Session("HitCounter"))
    End Function
End Class

' </Snippet1>
