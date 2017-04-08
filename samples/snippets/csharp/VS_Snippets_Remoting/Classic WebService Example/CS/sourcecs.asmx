// <Snippet1>
<%@ WebService Language="C#" Class="Util" %>
 
 using System;
 using System.Web.Services;
 
 public class Util: WebService {
   [ WebMethod(Description="Returns the time as stored on the Server",
   EnableSession=false)]
   public string Time() {
      return Context.Timestamp.TimeOfDay.ToString();
   }
 }
 
// </Snippet1>
