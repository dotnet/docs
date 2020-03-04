<%@ WebService Language="VB" Class="MathService1" %>

Imports System
Imports System.Web.Services

Public Class MathService1
   Inherits WebService
   <WebMethod()>  _
   Public Function Subtract(a As Single, b As Single) As Single
      Return a - b
   End Function 'Subtract
End Class 'MathService1 