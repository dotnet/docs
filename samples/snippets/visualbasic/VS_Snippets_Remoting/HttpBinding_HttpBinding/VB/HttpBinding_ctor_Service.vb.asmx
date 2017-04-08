<%@WebService Language="VB" Class="MyHttpBindingService"%>

Imports System
Imports System.Web.Services

Public Class MyHttpBindingService
   Inherits System.Web.Services.WebService
   
   <WebMethod()> _
   Public Function AddNumbers(firstNumber As Integer, secondNumber As Integer) As Integer
      Return firstNumber + secondNumber
   End Function 'AddNumbers
End Class 'MyHttpBindingService