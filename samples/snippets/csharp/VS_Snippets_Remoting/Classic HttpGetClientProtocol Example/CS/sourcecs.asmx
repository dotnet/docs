// <Snippet2>
<%@ WebService Language="C#" Class="Math"%>
 using System.Web.Services;
 using System;
 
 public class Math {
      [ WebMethod ]
      public int Add(int num1, int num2) {
          return num1+num2;
          }
 }
// </Snippet2>

