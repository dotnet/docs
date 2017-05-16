//<Snippet1>
<%@ WebService Language="C#" Class="SoapDocumentMethodSample" %>
	
using System.Web.Services;
using System.Web.Services.Protocols;

public class SoapDocumentMethodSample
{
   [WebMethod]
   [SoapDocumentMethod(RequestNamespace="http://www.contoso.com",RequestElementName="MyCustomElement")]
   public int[] RequestDocument(int numentries)
   {
	int[] intarray = new int[numentries];
        for (int i=0;i<numentries;i++)
        {
	   intarray[i] = i;
        }
        return intarray;
   }
}
//</Snippet1>