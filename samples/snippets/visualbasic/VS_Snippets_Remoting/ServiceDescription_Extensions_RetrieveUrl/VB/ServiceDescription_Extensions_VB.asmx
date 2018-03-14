<%@ WebService Language="VB" Class="ServiceDescriptionService" %>

' This program creates a WebService to add two numbers.
Imports System
Imports System.Web.Services

Public Class ServiceDescriptionService
   Inherits WebService

<WebMethod()>  _
   Public Function Add(a As Integer, b As Integer) As Integer
      Return a + b
   End Function 'Add
End Class 'ServiceDescriptionService