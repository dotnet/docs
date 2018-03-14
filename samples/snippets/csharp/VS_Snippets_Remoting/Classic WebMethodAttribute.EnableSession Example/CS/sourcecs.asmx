// <Snippet1>
<%@ WebService Language="C#" Class="Util" %>
 
 using System.Web.Services;
 
 public class Util: WebService {
   [ WebMethod(Description="Per session Hit Counter",EnableSession=true)]
    public int SessionHitCounter() {
       if (Session["HitCounter"] == null) {
          Session["HitCounter"] = 1;
       }
       else {
          Session["HitCounter"] = ((int) Session["HitCounter"]) + 1;
          }
       return ((int) Session["HitCounter"]);
    }   
 }

// </Snippet1>
