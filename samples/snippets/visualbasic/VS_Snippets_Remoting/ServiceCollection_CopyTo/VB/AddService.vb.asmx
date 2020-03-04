<%@ WebService Language="VB" Class="MathService" %>

Imports System
Imports System.Web.Services

Public Class MathService
   Inherits WebService
   <WebMethod()>  _
   Public Function Add(a As Single, b As Single) As Single
      Return a + b
   End Function 'Add
End Class 'MathService