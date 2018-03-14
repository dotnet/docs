<%@WebService Language="vb" Class="MimeText_Match_MatchCollService"%>

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services

Public Class MimeText_Match_MatchCollService
   Inherits System.Web.Services.WebService

   <WebMethod()> _
   Public Function AddNumbers(firstNumber As Integer, secondNumber As Integer) As Integer
      Return firstNumber + secondNumber
   End Function 'AddNumbers
End Class 'MimeText_Match_MatchCollService
