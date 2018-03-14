' <Snippet1>
<%@ WebService Language="VB" Class="Calculator" %>

Imports System
Imports System.Web.Services

Public Class Calculator
    Inherits WebService
    
    ' The MessageName property defaults to Add for this XML Web service method.
    <WebMethod()> _
    Overloads Public Function Add(i As Integer, j As Integer) As Integer
        
        Return i + j
    End Function
    
    <WebMethod(MessageName := "Add2")> _
    Overloads Public Function Add(i As Integer, j As Integer, k As Integer) As Integer
        
        Return i + j + k
    End Function    
End Class

' </Snippet1>
