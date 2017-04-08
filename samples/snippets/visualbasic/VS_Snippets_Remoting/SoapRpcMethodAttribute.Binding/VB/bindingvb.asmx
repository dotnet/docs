'<Snippet1>
<%@ WebService Language="VB" class="BindingSample" %>
 Imports System.Web.Services
 Imports System.Web.Services.Protocols

 ' Three bindings are defined
   < WebServiceBinding(Name:="LocalBinding"), _
   WebServiceBinding(Name:="LocalBindingNonDefaultNamespace",Namespace:="http://www.contoso.com/MyBinding"), _
   WebServiceBinding(Name:="RemoteBinding",Namespace:="http://www.contoso.com/MyBinding",Location:="http://www.contoso.com/MySevice.asmx?wsdl")> _
 Public class BindingSample  

	  < SoapRpcMethod(Binding:="LocalBinding"), WebMethod > _
	  Public Function LocalBindingMethod() As String
       		Return "Member of binding defined in this XML Web service and member of the default namespace"
      	  End Function

          < SoapRpcMethodAttribute(Binding:="LocalBindingNonDefaultNamespace"), WebMethod > _
	  Public Function LocalBindingNonDefaultNamespaceMethod() As String
  		Return "Member of binding defined in this XML Web service, but a part of a different namespace"
	  End Function
    
          < SoapRpcMethodAttribute(Binding:="RemoteBinding"), WebMethod > _
	  Public Function RemoteBindingMethod() As String
 		Return "Member of a binding defined on another server"
	  End Function

          < WebMethod > _
	  Public Function DefaultBindingMethod() As String
  		Return "Member of the default binding"
 	  End Function
End Class    
'</Snippet1>