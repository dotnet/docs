using System;
using System.Xml.Serialization;
using System.Web.Services.Protocols;


namespace MyMath {
    [XmlRootAttribute("int", Namespace="http://MyMath/", IsNullable=false)]
    public class Math : HttpGetClientProtocol {
       public Math() 
       {
          this.Url = "http://www.contoso.com/math.asmx";
       }
        
       [HttpMethodAttribute(typeof(System.Web.Services.Protocols.XmlReturnReader),
       typeof(System.Web.Services.Protocols.UrlParameterWriter))]
       public int Add(int num1, int num2) 
       {
          return ((int)(this.Invoke("Add", ((this.Url) + ("/Add")), new object[] {num1,
                         num2})));
       }
       public int Divide(int num1, int num2) 
       {
          return 0;
       }	
         
       public IAsyncResult BeginAdd(int num1, int num2, AsyncCallback callback, object asyncState) 
       {
          return this.BeginInvoke("Add", ((this.Url) + ("/Add")), new object[] {num1,
                         num2}, callback, asyncState);
       }
         
       public int EndAdd(IAsyncResult asyncResult) 
       {
          return ((int)(this.EndInvoke(asyncResult)));
       }
         
     }
 }

