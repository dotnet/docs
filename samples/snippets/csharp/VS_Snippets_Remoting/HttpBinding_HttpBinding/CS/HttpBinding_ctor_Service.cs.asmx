<%@WebService Language="c#" Class="MyHttpBindingService"%>

using System;
using System.Web.Services;

public class MyHttpBindingService: System.Web.Services.WebService
{
   
   
   [WebMethod]
   public int AddNumbers(int firstNumber,int secondNumber)
   {
      return firstNumber+secondNumber;
   }
}
