// <Snippet1>
<%@ WebService Language="C#" Class="Util"%>
 using System.Web.Services;
 
 public class Util: WebService {
   [ WebMethod(Description="Application Hit Counter",EnableSession=false)]
    public int HitCounter() {
       if (Application["HitCounter"] == null) {
          Application["HitCounter"] = 1;
       }
       else {
          Application["HitCounter"] = ((int) Application["HitCounter"]) + 1;
          }
       return ((int) Application["HitCounter"]);
    }   
 }
    
// </Snippet1>
