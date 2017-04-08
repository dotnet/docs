<%@WebService Language="c#" Class="OperationService"%>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

public class OperationService: System.Web.Services.WebService
{
   [WebMethod]
   public int AddNumbers(int firstNumber,int secondNumber)
   {
      return firstNumber+secondNumber;
   }
}
