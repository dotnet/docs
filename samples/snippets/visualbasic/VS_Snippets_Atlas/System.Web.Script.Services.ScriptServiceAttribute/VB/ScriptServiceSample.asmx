<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="SimpleWebService" %>

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ScriptService()> _
Public Class SimpleWebService
    Inherits System.Web.Services.WebService
    
    <WebMethod()> _
    Public Function GetServerTime() As String
        Dim serverTime As String = _
         String.Format("The current time is {0}.", DateTime.Now)
	    
        Return serverTime
    End Function

End Class
' </Snippet1>
