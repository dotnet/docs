// <Snippet1>
<%@ WebService Language="C#" Class="Stats" %>
 
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 public class Stats: WebService {
 
      [ SoapRpcMethod(OneWay=true) ]
      [ WebMethod(Description="Starts nightly stats batch process.") ]
      public void StartStatsCrunch() {
         // Begin a process that takes a long time to complete.
      }      
 
 }

// </Snippet1>
