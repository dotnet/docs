<%@ WebService language="C#" class="BindingSample" %>

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

// <Snippet1>
// Binding is defined on a remote server, but this XML Web service 
// implements at least one operation in that binding.
[ WebServiceBinding(Name="RemoteBinding",
    Namespace="http://www.contoso.com/MyBinding",
    Location="http://www.contoso.com/MyService.asmx?wsdl")]
public class BindingSample  
{
    [ SoapDocumentMethod(Binding="RemoteBinding")] 
    [ WebMethod() ]
    public string RemoteBindingMethod() 
    {
        return "Member of a binding defined on another server";
    }
}

// </Snippet1>
