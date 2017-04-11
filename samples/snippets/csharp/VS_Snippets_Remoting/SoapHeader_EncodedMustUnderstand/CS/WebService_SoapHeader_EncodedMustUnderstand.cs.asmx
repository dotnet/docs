<%@ WebService Language="C#" Class="WebService_SoapHeader_EncodedMustUnderstand" %>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

public class MyHeader : SoapHeader
{
   public string MyValue;
}

public class WebService_SoapHeader_EncodedMustUnderstand : System.Web.Services.WebService
{
   public MyHeader myHeader1;
   // Receive all SOAP headers besides the MyHeader SOAP header.
   public SoapUnknownHeader[] unknownHeaders;

   [WebMethod(Description="This Web Service method requires a client to send the MyHeader SOAP header.")]
   [SoapHeader("myHeader1", Direction=SoapHeaderDirection.In,Required=true)]

   // Receive any SOAP headers other than MyHeader.
   [SoapHeader("unknownHeaders",Required=false)]

   public string MyWebMethod1() 
   {
      foreach (SoapUnknownHeader myUnknownHeader in unknownHeaders) 
      {
         // Perform some processing on header.
         if (myUnknownHeader.Element.Name == "MyKnownHeader")
         {
            myUnknownHeader.DidUnderstand = true;
         }
         else
         {
            // Set the DidUnderstand to false.
            myUnknownHeader.DidUnderstand = false;
         }
      }
         return "WebMethod1 called.";
   }
   [WebMethod(Description="This Web Service method requires a client to send the MyHeader SOAP header.")]
   [SoapHeader("myHeader1", Direction=SoapHeaderDirection.In,Required=true)]

   // Receive any SOAP headers other than MyHeader.
   [SoapHeader("unknownHeaders",Required=false)]

   public string MyWebMethod2() 
   {
      myHeader1.DidUnderstand = false;
      foreach (SoapUnknownHeader myUnknownHeader in unknownHeaders) 
      {
         // Perform some processing on myUnknownHeader.
         if (myUnknownHeader.Element.Name == "MyKnownHeader")
         {
            myUnknownHeader.DidUnderstand = true;
         }
         else
         {
            // Set the DidUnderstand to false.
            myUnknownHeader.DidUnderstand = false;
         }
      }
         return "Web Method2 Called.";
   }
}
