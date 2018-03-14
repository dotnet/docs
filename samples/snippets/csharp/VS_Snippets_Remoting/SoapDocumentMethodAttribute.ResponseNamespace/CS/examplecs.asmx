//<Snippet1>
<%@ WebService Language="C#" Class="SoapDocumentMethodSample" %>
	
using System.Web.Services;
using System.Web.Services.Protocols;

public class SoapDocumentMethodSample
{
   [WebMethod]
   [SoapDocumentMethod(ResponseNamespace="http://www.contoso.com",ResponseElementName="MyCustomResponseElement")]
   public int[] ResponseDocument(int numentries)
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