<%@ WebService Language="VB" class="BindingSample" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' <Snippet1>
' Binding is defined in this XML Web service, but it is not a part of the default namespace.
<WebServiceBinding(Name := "LocalBindingNonDefaultNamespace", _
    Namespace := "http://www.contoso.com/MyBinding")> _
Public Class BindingSample   
    
    <SoapDocumentMethod(Binding := "LocalBindingNonDefaultNamespace"), _
        WebMethod()> _
    Public Function LocalBindingNonDefaultNamespaceMethod() As String
        
        Return "Member of binding defined in this XML Web service, but a part " & _
               "of a different namespace"
    End Function
End Class
 
' </Snippet1>
