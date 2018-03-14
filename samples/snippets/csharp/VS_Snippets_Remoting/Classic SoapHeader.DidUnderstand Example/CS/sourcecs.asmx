// <Snippet1>
<%@ WebService Language="C#" Class="MyWebService"%>
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System;

// Define a SOAP header by deriving from the SoapHeader base class.

public class MyHeader : SoapHeader {
    public string MyValue;
}

public class MyWebService {

    public MyHeader myHeader;
    // Receive all SOAP headers besides the MyHeader SOAP header.
    public SoapUnknownHeader[] unknownHeaders;
 
    [WebMethod]
    [SoapHeader("myHeader", Direction=SoapHeaderDirection.InOut)]

    //Receive any SOAP headers other than MyHeader.
    [SoapHeader("unknownHeaders",Required=false)]

    public string MyWebMethod() {

       foreach (SoapUnknownHeader header in unknownHeaders) {
           // Perform some processing on the header.
       if (header.Element.Name == "MyKnownHeader")
               header.DidUnderstand = true;
       else
                // For those headers that cannot be  
                // processed, set the DidUnderstand property to false.
                header.DidUnderstand = false;
       }
       return "Hello";
    }
}

// </Snippet1>
