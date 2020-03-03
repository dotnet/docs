/*
   This program is just used to show a client proxy which helps 
   accessing a web service.
*/

using System;
using System.Web.Services.Protocols;

public class MySoapHeader : SoapHeader
{
   public int number;
}

[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap", Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   public MySoapHeader mySoapHeader;
   
   [SoapHeaderAttribute("mySoapHeader", Direction=SoapHeaderDirection.In)]
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   public System.Single Add(System.Single xValue, System.Single yValue) 
   {
      mySoapHeader = new MySoapHeader();
      mySoapHeader.number = 0;
      object[] results = this.Invoke("Add", new object[] {
                                                            xValue,
                                                            yValue});
      return ((System.Single)(results[0]));
   }

   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapHeaderException2.cs.asmx";
   }

   public System.IAsyncResult BeginAdd(System.Single xValue,
                                       System.Single yValue,
                                       System.AsyncCallback callback,
                                       object asyncState) 
   {
      return this.BeginInvoke("Add", new object[] {
                                       xValue,
                                       yValue}, callback, asyncState);
   }

   public System.Single EndAdd(System.IAsyncResult asyncResult) 
   {
      object[] results = this.EndInvoke(asyncResult);
      return ((System.Single)(results[0]));
   }
}
