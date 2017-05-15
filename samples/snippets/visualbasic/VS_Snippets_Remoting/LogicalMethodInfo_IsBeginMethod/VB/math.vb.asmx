<%@ WebService Language="vb" Class="MyMath" %>

Imports System.Web.Services
Imports System

Public Class MyMath
   <WebMethod> Public Function Add(ByVal x As Integer, ByVal y As Integer) As Integer
      Return x + y
   End Function
End Class

