<%@WebService Language="c#" Class="MimeText_Match_MatchCollService"%>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

public class MimeText_Match_MatchCollService: System.Web.Services.WebService
{
   [WebMethod]
   public int AddNumbers(int firstNumber,int secondNumber)
   {
      return firstNumber+secondNumber;
   }
}
