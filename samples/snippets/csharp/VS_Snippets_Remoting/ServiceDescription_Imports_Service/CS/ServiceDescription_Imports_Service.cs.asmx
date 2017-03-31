<%@ WebService Language="c#" Class="ServiceDescriptionService" %>
using System;
using System.Web;
using System.Web.Services;

public class ServiceDescriptionService : WebService
{
   [WebMethod]
   public int Add(int a, int b)
   {
      return(a+b);
   }
}