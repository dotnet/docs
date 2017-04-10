<%@ WebService Language="C#" Class="MathService" %>

using System;
using System.Web.Services;

public class MathService : WebService {

   [WebMethod]
   public float Add(float a, float b)
   {
       return a + b;
   }

   [WebMethod]
   public float Subtract(float a, float b)
   {
       return a - b;
   }

   [WebMethod]
   public float Multiply(float a, float b)
   {
       return a * b;
   }

   [WebMethod]
   public float Divide(float a, float b)
   {
       if (b==0) return -1;
       return a / b;
   }

}