// <Snippet1>
using System;
using System.Web.Services;
using System.Web.Services.Protocols;

// Define a SOAP header by deriving from the SoapHeader base class.
// The header contains just one string value.
public class MyHeader : SoapHeader {
    public string MyValue;
}

public class MyWebService {
    // Member variable to receive the contents of the MyHeader SOAP header.
    public MyHeader myHeader;
 
    [WebMethod]
    [SoapHeader("myHeader", Direction=SoapHeaderDirection.InOut)]
    public void Hello() {
    
    }
}
// </Snippet1>
