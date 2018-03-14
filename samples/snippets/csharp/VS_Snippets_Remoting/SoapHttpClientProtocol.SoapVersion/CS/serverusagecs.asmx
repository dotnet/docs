<%@ WebService Language="C#" Class="ServerUsage" %>

//<Snippet2>
using System.Web.Services;

public class ServerUsage : WebService {
	 
     [ WebMethod(Description="Number of times this service has been accessed") ]
     public int ServiceUsage() {
	      // If the XML Web service method hasn't been accessed initialize it to 1    
          if (Application["MyServiceUsage"] == null) {
              Application["MyServiceUsage"] = 1;
          }
          else {
              // Increment the usage count
              Application["MyServiceUsage"] = ((int) Application["MyServiceUsage"]) + 1;
          }

	  return  (int) Application["MyServiceUsage"];
     }

     [ WebMethod(Description="Number of times a particualr client session has accessed this XML Web service method accessed",EnableSession=true) ]
     public int PerSessionServiceUsage() {
   	      // If the XML Web service method hasn't been accessed initialize it to 1    
          if (Session["MyServiceUsage"] == null) {
              Session["MyServiceUsage"] = 1;
          }
          else {
              // Increment the usage count
              Session["MyServiceUsage"] = ((int) Session["MyServiceUsage"]) + 1;
          }

	  return  (int) Session["MyServiceUsage"];
     }
   
}
//</Snippet2>