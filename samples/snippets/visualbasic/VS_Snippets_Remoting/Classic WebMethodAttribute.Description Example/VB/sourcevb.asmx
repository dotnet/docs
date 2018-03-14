' <Snippet1>
<%@ WebService Language="VB" Class="Util" %>

Imports System
Imports System.Web.Services

Public Class Util
    Inherits WebService

    <WebMethod(Description := "Obtains the Server Computer Name", _
        EnableSession := False)> _
    Public Function GetMachineName() As String
        
        Return Server.MachineName
    End Function
End Class

' </Snippet1>
