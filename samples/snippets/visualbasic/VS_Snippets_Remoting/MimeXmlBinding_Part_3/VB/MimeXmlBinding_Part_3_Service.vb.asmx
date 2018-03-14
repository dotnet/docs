<%@WebService Language="vb" Class="MimeXmlBinding_Part_3_Service"%>

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services

Public Class MimeXmlBinding_Part_3_Service
   Inherits System.Web.Services.WebService

   <WebMethod()> _
   Public Function AddNumbers(firstNumber As Integer, secondNumber As Integer) As Integer
      Return firstNumber + secondNumber
   End Function 'AddNumbers
End Class 'MimeXmlBinding_Part_3_Service
