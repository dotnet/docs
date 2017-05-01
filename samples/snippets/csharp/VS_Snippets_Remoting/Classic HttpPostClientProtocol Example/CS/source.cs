//<Snippet1>
using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.Web.Services;


public class MyMath : System.Web.Services.Protocols.HttpPostClientProtocol {
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    public MyMath() {
        this.Url = "http://www.contoso.com/math.asmx";
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Web.Services.Protocols.HttpMethodAttribute(typeof(System.Web.Services.Protocols.XmlReturnReader), typeof(System.Web.Services.Protocols.HtmlFormParameterWriter))]
    [return: System.Xml.Serialization.XmlRootAttribute("int", Namespace="http://www.contoso.com/", IsNullable=false)]
    public int Add(string num1, string num2) {
        return ((int)(this.Invoke("Add", (this.Url + "/Add"), new object[] {num1,
                    num2})));
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    public System.IAsyncResult BeginAdd(string num1, string num2, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Add", (this.Url + "/Add"), new object[] {num1,
                    num2}, callback, asyncState);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    public int EndAdd(System.IAsyncResult asyncResult) {
        return ((int)(this.EndInvoke(asyncResult)));
    }
}
//</Snippet1>