' <Snippet1>
<%@ WebService Language="VB" Class="MyWebService"%>

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports System

' Define a SOAP header by deriving from the SoapHeader base class.
Public Class MyHeader
    Inherits SoapHeader
    Public MyValue As String
End Class

Public Class MyWebService
    
    Public theHeader As MyHeader
    ' Receive all SOAP headers besides the MyHeader SOAP header.
    Public unknownHeaders() As SoapUnknownHeader    

    'Receive any SOAP headers other than MyHeader.    
    <WebMethod, _
     SoapHeader("theHeader", Direction := SoapHeaderDirection.InOut), _
     SoapHeader("unknownHeaders")> _
    Public Function MyWebMethod() As String
                
        Dim header As SoapUnknownHeader
        For Each header In unknownHeaders
            ' Perform some processing on the header.
            If header.Element.Name = "MyKnownHeader" Then
                header.DidUnderstand = True
            Else
                ' For those headers that cannot be
                ' processed, set the DidUnderstand propert to false.
                header.DidUnderstand = False
            End If
        Next header
        Return "Hello"
    End Function
    
End Class

' </Snippet1>
