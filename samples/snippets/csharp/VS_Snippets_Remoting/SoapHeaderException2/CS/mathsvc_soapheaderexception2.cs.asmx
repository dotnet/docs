// System.Web.Services.Protocols.SoapHeaderException(string, XmlQualifiedName, Exception)
/*
   The following example demonstrates the constructor 
   'SoapHeaderException(string, XmlQualifiedName, Exception)'
   of the 'SoapHeaderException' class. The XML Web service method 
   throws a 'SoapHeaderException' when an exception is thrown during
   header processing. This exception is sent to the client
   and the information leading to the exception is made
   available on the client that invoked the XML Web service
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
      // Process the header from the client.
      try 
      {
         int j = 100/mySoapHeader.number;
      }
      catch(Exception e)
      {
         // Throw a SoapHeaderException if an exception is caught during 
         // header processing.
         throw new SoapHeaderException(
            "An Exception was thrown during the processing of header",
            SoapException.ClientFaultCode, e);
      }
      return(xValue + yValue);
   }
}
// </Snippet1>
