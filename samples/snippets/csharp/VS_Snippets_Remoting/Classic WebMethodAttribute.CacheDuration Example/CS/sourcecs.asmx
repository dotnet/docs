// <Snippet1>
<%@ WebService Language="C#" Class="Counter" %>

using System.Web.Services;
using System;
using System.Web;

public class Counter : WebService {
     
     [ WebMethod(Description="Number of times this service has been accessed",
     CacheDuration=60,MessageName="ServiceUsage") ]
     public int ServiceUsage() {
          // If the XML Web service has not been accessed, initialize it to 1.
          if (Application["MyServiceUsage"] == null) {
              Application["MyServiceUsage"] = 1;
          }
          else {
              // Increment the usage count.
              Application["MyServiceUsage"] = ((int) Application["MyServiceUsage"]) + 1;
          }

          // Return the usage count.     
          return  (int) Application["MyServiceUsage"];
     }
}

// </Snippet1>
