using System;
using System.Web;
using System.Web.UI;

// <Snippet1>
public class MyUser : System.Web.Services.Protocols.HttpPostClientProtocol {
    
    public MyUser() {
        this.Url = "http://www.contoso.com/username.asmx";
    }
    
    [System.Web.Services.Protocols.HttpMethodAttribute(typeof(System.Web.Services.Protocols.XmlReturnReader), typeof(System.Web.Services.Protocols.HtmlFormParameterWriter))]
    public UserName GetUserName() {
        return ((UserName)(this.Invoke("GetUserName", (this.Url + "/GetUserName"), new object[0])));
    }
    
    public System.IAsyncResult BeginGetUserName(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetUserName", (this.Url + "/GetUserName"), new object[0], callback, asyncState);
    }
    
    public UserName EndGetUserName(System.IAsyncResult asyncResult) {
        return ((UserName)(this.EndInvoke(asyncResult)));
    }
}

[System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=true)]
public class UserName {
    
    public string Name;
    
    public string Domain;
}
   
// </Snippet1>
