<%@ WebService Language="C#" class="BindingSample" %>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;

// <Snippet1>
// Binding is defined in this XML Web service and uses the default namespace.
 [ WebServiceBinding(Name="LocalBinding")]
 public class BindingSample  {

      [ SoapDocumentMethod(Binding="LocalBinding")]
      [ WebMethod() ]
      public string LocalBindingMethod() {
               return "Member of binding defined in this XML Web service and member of the default namespace";
      }

 }
   
// </Snippet1>

