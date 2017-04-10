using System;
using System.Web;
using System.Web.UI;
using System.Net;

public class Page1: Page {
        private void Page_Load(Object sender, EventArgs e) {
        // <Snippet1>
        MyMath.Math math = new MyMath.Math();

        // Set the proxy server to proxyserver, set the port to 80, and specify to bypass the proxy server
        // for local addresses.
        IWebProxy proxyObject = new WebProxy("http://proxyserver:80", true);
        math.Proxy = proxyObject;

        // Call the Add XML Web service method.
        int total = math.Add(8, 5);
        // </Snippet1>
    }

    public static void Main() {}
}

namespace MyMath {
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    

    public class Math : SoapHttpClientProtocol {

	public int Add(int num1, int num2) {return num1 + num2;}

    }
}