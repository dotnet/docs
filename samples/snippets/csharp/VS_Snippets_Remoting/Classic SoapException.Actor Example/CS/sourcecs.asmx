// <Snippet2>
<%@ WebService Language="C#" Class="Math"%>
 using System.Web.Services;
 using System;
 public class Math : WebService {
     [WebMethod]
     public float Divide(int dividend, int divisor) {
         if (divisor == 0)
             throw new DivideByZeroException();
 
         return dividend/divisor;
     }
  }
// </Snippet2>


