// System.Web.Services.Protocols.SoapHeaderException(string, XmlQualifiedName)

/*
   The following example demonstrates the constructor 
   'SoapHeaderException(string, XmlQualifiedName)'of the 
   'SoapHeaderException' class. The web service method 
   throws an exception whenever the value contained within 
   the header is zero. This exception is sent to the client
   and the information leading to the exception is made
   available on the client that invoked the web service
   method. 
*/
// <Snippet1>
<%@ WebService Language="C#" Class="MathSvc" %>

using System;
using System.Web.Services;
using System.Web.Services.Protocols;

public class MySoapHeader : SoapHeader
{
   public int number;
}

public class MathSvc : WebService {
    public MySoapHeader mySoapHeader;
    
    [WebMethod]
    [SoapHeaderAttribute("mySoapHeader", Direction=SoapHeaderDirection.In)]
    public float Add(float xValue, float yValue) 
    {
        // Throw an exception if the value received in the header is zero.
        if(mySoapHeader.number == 0)
            throw new SoapHeaderException(
               "value received in the header is zero.",
               SoapException.ClientFaultCode);
        return(xValue + yValue);
    }
}
// </Snippet1>