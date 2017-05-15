// <Snippet1>
<%@ WebService Language="C#" Class="MyWebService"%>
using System.Web.Services;
using System.Web.Services.Protocols;

// Define a SOAP header by deriving from the SoapHeader base class.
// The header contains just one string value.
public class MyHeader : SoapHeader {
    public string MyValue;
}

public class MyWebService {
    // Member variable to receive the contents of the MyHeader SoapHeader.
    public MyHeader myHeader;

    // Member variable to receive all headers other than MyHeader.
    public SoapUnknownHeader[] unknownHeaders;
 
    [WebMethod]
    [SoapHeader("myHeader", Direction=SoapHeaderDirection.InOut)]

    // Receive any SOAP headers other than MyHeader.
    [SoapHeader("unknownHeaders")]
    public void Hello() {

       // Process the MyHeader SoapHeader.
       if (myHeader.MyValue == "Some string") {
          // Process the header.
       }
       foreach (SoapHeader header in unknownHeaders) {
           // Perform some processing on header.
           
           // For those headers that cannot be processed,
           // set the DidUnderstand property to false.
           header.DidUnderstand = false;
       }
    }
}

// </Snippet1>
