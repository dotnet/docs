// <Snippet1>
<%@ WebService Language="C#" class="BindingSample" %>
 using System;
 using System.Web.Services;
 using System.Web.Services.Protocols;

 // Binding is defined in this XML Web service and uses the default namespace.
 [ WebServiceBinding(Name="LocalBinding")]

 // Binding is defined in this XML Web service, but it is not a part of the default namespace.
 [ WebServiceBinding(Name="LocalBindingNonDefaultNamespace", 
		     Namespace="http://www.contoso.com/MyBinding" )]

 // Binding is defined on a remote server, but this XML Web service implements at least one operation in that binding.
 [ WebServiceBinding(Name="RemoteBinding", 
		  Namespace="http://www.contoso.com/MyBinding",
		  Location="http://www.contoso.com/MySevice.asmx?wsdl")]
 public class BindingSample  {

      [ SoapDocumentMethod(Binding="LocalBinding")]
      [ WebMethod() ]
      public string LocalBindingMethod() {
               return "Member of binding defined in this XML Web service and member of the default namespace";
      }
      [ SoapDocumentMethod(Binding="LocalBindingNonDefaultNamespace")] 
      [ WebMethod() ]
      public string LocalBindingNonDefaultNamespaceMethod() {
              return "Member of binding defined in this XML Web service, but a part of a different namespace";
      }

     [ SoapDocumentMethod(Binding="RemoteBinding")] 
     [ WebMethod() ]
      public string RemoteBindingMethod() {
              return "Member of a binding defined on another server";
      }

      [ WebMethod() ]
      public string DefaultBindingMethod() {
              return "Member of the default binding";
      }
 
 }

// </Snippet1>
