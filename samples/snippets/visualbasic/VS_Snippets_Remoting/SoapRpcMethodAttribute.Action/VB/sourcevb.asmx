' <Snippet1>
<%@ WebService Language="VB" class="MyUser" %>
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class MyUser
    Inherits WebService    
    
    <SoapRpcMethod(Action := "http://www.contoso.com/Sample", _
    RequestNamespace := "http://www.contoso.com/Request", _
    RequestElementName := "GetUserNameRequest", _
    ResponseNamespace := "http://www.contoso.com/Response", _
    ResponseElementName := "GetUserNameResponse"), _
    WebMethod(Description := "Obtains the User Name")> _
    Public Function _
        GetUserName() As UserName
        
        Dim temp As String
        Dim pos As Integer
        Dim NewUser As New UserName()
        
        ' Get the full user name, including the domain name if applicable.
        temp = User.Identity.Name
        
        ' Deterime whether the user is part of a domain by searching for a backslash.
        pos = temp.IndexOf("\")
        
        ' Parse the domain name out of the string, if one exists.
        If pos <= 0 Then
            NewUser.Name = User.Identity.Name
        Else
            NewUser.Name = temp.Remove(0, pos + 1)
            NewUser.Domain = temp.Remove(pos, temp.Length - pos)
        End If
        Return NewUser
    End Function
End Class 

Public Class UserName
    
    Public Name As String
    Public Domain As String
End Class

' </Snippet1>
