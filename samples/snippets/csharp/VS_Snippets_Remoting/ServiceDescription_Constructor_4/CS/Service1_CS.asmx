<%@ WebService Language="c#" Class="Service1" %>

// This program creates a WebService to add two numbers.
using System;
using System.Web.Services;

public class Service1 : WebService
{
   [WebMethod]
   public int Add(int a, int b)
   {
      return(a+b);
   }
}


