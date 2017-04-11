<%@ WebService Language="VB" Class="MathService" %>
Imports System
Imports System.Web.Services

Public Class MathService
   Inherits WebService

   <WebMethod()>  _
   Public Function Add(a As Single, b As Single) As Single
      Return a + b
   End Function 

   <WebMethod()>  _
   Public Function Subtract(a As Single, b As Single) As Single
      Return a - b
   End Function 

   <WebMethod()>  _
   Public Function Multiply(a As Single, b As Single) As Single
      Return a * b
   End Function 

   <WebMethod()>  _
   Public Function Divide(a As Single, b As Single) As Single
      If b = 0 Then
         Return - 1
      End If
      Return a / b
   End Function 

End Class 