[System.Web.Services.WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public class MathSvc : System.Web.Services.Protocols.SoapHttpClientProtocol 
{ 
   public SoapHeader[] mySoapHeaders;
   
   [SoapHeaderAttribute("mySoapHeaders", 
      Direction=SoapHeaderDirection.In)]
   [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
      "http://tempuri.org/Add", 
      Use=System.Web.Services.Description.SoapBindingUse.Literal, 
      ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
   [MySoapExtensionAttribute()]
   public System.Single Add(System.Single xValue, System.Single yValue) 
   {
      SoapHeaderCollection mySoapHeaderCollection = new SoapHeaderCollection();
      MySoapHeader mySoapHeader;
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This is the first SOAP header";
      mySoapHeaderCollection.Add(mySoapHeader);
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This is the second SOAP header";
      mySoapHeaderCollection.Add(mySoapHeader);
      mySoapHeader = new MySoapHeader();
      mySoapHeader.text = "This header is inserted before the first header";
      mySoapHeaderCollection.Insert(0, mySoapHeader);
      mySoapHeaders = new MySoapHeader[mySoapHeaderCollection.Count];
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0);
      object[] results = this.Invoke("Add", 
         new object[] {xValue, yValue});
      return ((System.Single)(results[0]));
   }

   [System.Diagnostics.DebuggerStepThroughAttribute()]
   public MathSvc() 
   {
      this.Url = "http://localhost/MathSvc_SoapHeaderCollection.cs.asmx";
   }

   public System.IAsyncResult BeginAdd(System.Single xValue,
      System.Single yValue, System.AsyncCallback callback, object asyncState) 
   {
      return this.BeginInvoke("Add", new object[] {xValue, yValue}, 
         callback, asyncState);
   }

   public System.Single EndAdd(System.IAsyncResult asyncResult) 
   {
      object[] results = this.EndInvoke(asyncResult);
      return ((System.Single)(results[0]));
   }
}