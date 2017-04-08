//<Snippet1>
<%@ WebService Language="C#" Class="SoapRpcMethodSample" %>
	
using System.Web.Services;
using System.Web.Services.Protocols;

public class SoapRpcMethodSample
{
   [WebMethod]
   [SoapRpcMethod(RequestNamespace="http://www.contoso.com",RequestElementName="MyCustomRequestElement")]
   public int[] RequestRpc(int numentries)
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