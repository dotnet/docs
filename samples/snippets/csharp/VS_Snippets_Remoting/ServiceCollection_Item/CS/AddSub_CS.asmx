<%@ WebService Language="C#" Class="MathService" %>

using System;
using System.Web.Services;

public class MathService: WebService
{
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
 }