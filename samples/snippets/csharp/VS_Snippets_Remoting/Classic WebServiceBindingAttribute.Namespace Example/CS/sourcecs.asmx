<%@ WebService Language="C#" class="BindingSample" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

// <Snippet1>
// Binding is defined in this XML Web service, but it is not a part of the default namespace.
 [ WebServiceBinding(Name="LocalBindingNonDefaultNamespace",
 Namespace="http://www.contoso.com/MyBinding")]
 public class BindingSample  {

      [ SoapDocumentMethod(Binding="LocalBindingNonDefaultNamespace")] 
      [ WebMethod() ]
      public string LocalBindingNonDefaultNamespaceMethod() {
              return "Member of binding defined in this XML Web service, but a part of a different namespace";
      }
 }
 
// </Snippet1>
