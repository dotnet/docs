<%@ WebService Language="c#" Class="ServiceDescriptionService" %>

// This program creates a WebService to add two numbers.
using System;
using System.Web.Services;

public class ServiceDescriptionService : WebService
{
   [WebMethod]
   public int Add(int a, int b)
   {
      return(a+b);
   }
}
