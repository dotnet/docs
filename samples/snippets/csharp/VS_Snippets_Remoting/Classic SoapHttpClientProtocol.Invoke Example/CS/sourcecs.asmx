// <Snippet2>
<%@ WebService Language="C#" Class="MyMath"%>
 using System.Web.Services;
 using System;
 
 [WebService(Namespace="http://www.contoso.com/")] 
 public class MyMath {
      [ WebMethod ]
      public int Add(int num1, int num2) {
          return num1+num2;
          }
 }
// </Snippet2>

