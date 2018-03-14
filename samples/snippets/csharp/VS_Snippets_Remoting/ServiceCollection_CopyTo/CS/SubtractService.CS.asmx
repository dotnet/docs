<%@ WebService Language="C#" Class="MathService1" %>

using System;
using System.Web.Services;

public class MathService1: WebService
{
   [WebMethod]
   public float Subtract(float a, float b)
   {
       return a - b;
   }

 }