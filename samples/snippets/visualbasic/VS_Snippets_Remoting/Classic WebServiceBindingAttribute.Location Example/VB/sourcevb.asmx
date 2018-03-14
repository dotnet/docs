<%@ WebService language="VB" class="BindingSample" %>

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' <Snippet1>
' Binding is defined on a remote server, but this XML Web service implements at
' least one operation in that binding.
<WebServiceBinding(Name := "RemoteBinding", _
    Namespace := "http://www.contoso.com/MyBinding", _
    Location := "http://www.contoso.com/MyService.asmx?wsdl")> _
Public Class BindingSample
        
    <SoapDocumentMethod(Binding := "RemoteBinding"), WebMethod()> _
    Public Function RemoteBindingMethod() As String
        Return "Member of a binding defined on another server"
    End Function
End Class

' </Snippet1>
