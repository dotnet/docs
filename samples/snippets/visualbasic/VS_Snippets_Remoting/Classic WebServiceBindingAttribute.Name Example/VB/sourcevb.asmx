<%@ WebService Language="VB" class="BindingSample" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

' <Snippet1>
' Binding is defined in this XML Web service and uses the default namespace.
<WebServiceBinding(Name := "LocalBinding")> _
Public Class BindingSample    
    
    <SoapDocumentMethod(Binding := "LocalBinding"), WebMethod()> _
    Public Function LocalBindingMethod() As String
    
        Return "Member of binding defined in this XML Web service and member of the default namespace"
    End Function 'LocalBindingMethod
    
End Class
   
' </Snippet1>

