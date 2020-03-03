<%@ WebService Language="C#" Class="Service1" %>
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

  public class Service1:WebService
  {
      [WebMethod]
      public int AddNumbers(int firstNumber,int secondNumber)
      {
         return firstNumber+secondNumber;
      }
  }

