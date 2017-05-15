// <Snippet1>
<%@ WebService Language="C#" Class="Calculator" %>
 
 using System;
 using System.Web.Services;
 
 public class Calculator : WebService {
    // The MessageName property defaults to Add for this XML Web service method.
    [WebMethod]
    public int Add(int i, int j) {
       return i + j;
    }   
    [WebMethod(MessageName="Add2")]
    public int Add(int i, int j, int k) {
       return i + j + k;
    }   
 }

// </Snippet1>
