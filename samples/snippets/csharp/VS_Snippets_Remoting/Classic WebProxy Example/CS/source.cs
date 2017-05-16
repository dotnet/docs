using System;
using System.Net;

public class Sample {

    private void sampleFunction() {
// <Snippet1>
WebProxy proxyObject = new WebProxy("http://proxyserver:80/",true);
WebRequest req = WebRequest.Create("http://www.contoso.com");
req.Proxy = proxyObject;

// </Snippet1>
        }
}
