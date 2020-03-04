<%@ WebService Language="C#"  Class = "MyMath" %>
using System.Web.Services;
using System;
 
public class MyMath 
{
   [ WebMethod ]public int Add(int num1, int num2) 
   {
      return num1+num2;
   }
}
