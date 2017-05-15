//<Snippet1>
<%@ WebService Language="C#" Class="SoapRpcMethodSample" %>
	
using System.Web.Services;
using System.Web.Services.Protocols;

public class SoapRpcMethodSample
{
   [WebMethod]
   [SoapRpcMethod(ResponseNamespace="http://www.contoso.com",ResponseElementName="MyCustomResponseElement")]
   public int[] ResponseRpc(int numentries)
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