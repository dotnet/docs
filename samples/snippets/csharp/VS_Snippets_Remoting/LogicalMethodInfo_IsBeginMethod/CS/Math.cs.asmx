<%@ WebService Language="c#" class="MyMath" %>

using System;
using System.Web.Services;

public class MyMath
{
   [WebMethod]
   public int Add(int x, int y)
   {
      return x + y;
   }
}