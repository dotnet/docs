// <Snippet1>
<%@ WebService Language="C#" Class="Stats" %>
 
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 public class Stats: WebService {
 
      [ SoapDocumentMethod(OneWay=true) ]
      [ WebMethod(Description="Starts nightly statistics batch process.") ]
      public void StartStatsCrunch() {
         // Begin nightly statistics crunching process.
         // A one-way method cannot have return values.
      }      
 
 }

// </Snippet1>
