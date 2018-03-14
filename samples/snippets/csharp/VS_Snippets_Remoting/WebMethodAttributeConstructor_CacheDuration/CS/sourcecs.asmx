// <Snippet1>
<%@ WebService Language="C#" Class="Counter" %>
<%@ assembly name="System.EnterpriseServices,Version=1.0.3300.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" %>

using System.Web.Services;
using System;
using System.Web;
using System.EnterpriseServices;

public class Counter : WebService {
     
     [ WebMethod(true,TransactionOption.NotSupported,60) ]
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
