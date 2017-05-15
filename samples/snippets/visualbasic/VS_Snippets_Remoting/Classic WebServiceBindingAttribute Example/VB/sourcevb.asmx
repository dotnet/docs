<!--<Snippet1>-->
<%@ WebService Language="VB" class="BindingSample" %>
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Binding is defined in this XML Web service and uses the default namespace.
' Binding is defined in this XML Web service, but it is not a part of the default
' namespace.
' Binding is defined on a remote server, but this XML Web service implements at
' least one operation in that binding.
<WebServiceBinding(Name := "LocalBinding"), _ 
 WebServiceBinding(Name := "LocalBindingNonDefaultNamespace", _ 
                   Namespace := "http://www.contoso.com/MyBinding"), _     
 WebServiceBinding(Name := "RemoteBinding", _ 
                   Namespace := "http://www.contoso.com/MyBinding", _
                   Location := "http://www.contoso.com/MySevice.asmx?wsdl")> _
Public Class BindingSample
    
    <SoapDocumentMethod(Binding := "LocalBinding"), WebMethod()> _
    Public Function LocalBindingMethod() As String
        
        Return "Member of binding defined in this XML Web service and member of the default namespace"
    End Function
    
    <SoapDocumentMethod(Binding := "LocalBindingNonDefaultNamespace"), WebMethod()> _
    Public Function LocalBindingNonDefaultNamespaceMethod() As String
    
        Return "Member o1f binding defined in this XML Web service, but a part of a different namespace"
    End Function    
    
    <SoapDocumentMethod(Binding := "RemoteBinding"), WebMethod()> _
    Public Function RemoteBindingMethod() As String
    
        Return "Member of a binding defined on another server"
    End Function    
    
    <WebMethod()> _
    Public Function DefaultBindingMethod() As String
    
        Return "Member of the default binding"
    End Function
End Class

'</Snippet1>
