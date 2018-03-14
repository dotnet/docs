' <Snippet1>
<%@ WebService Language="VB" Class="Counter" %>
<%@ assembly name="System.EnterpriseServices,Version=1.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" %>

Imports System.Web.Services
Imports System
Imports System.Web
Imports System.EnterpriseServices

Public Class Counter
    Inherits WebService  

    <WebMethod(true,TransactionOption.NotSupported,60)> _
    Public Function ServiceUsage() As Integer
        
        ' If the XML Web service has not been accessed, initialize it to 1.
        If Application("MyServiceUsage") Is Nothing Then
            Application("MyServiceUsage") = 1
        Else
            ' Increment the usage count.
            Application("MyServiceUsage") = CInt(Application("MyServiceUsage")) + 1
        End If
        
        ' Return the usage count.
        Return CInt(Application("MyServiceUsage"))
    End Function
End Class

' </Snippet1>
