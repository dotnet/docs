' <Snippet1>
<%@ WebService Language="VB" Class="MyWebService"%>
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Define a SOAP header by deriving from the SoapHeader base class.
' The header contains just one string value.
Public Class MyHeader
    Inherits SoapHeader
    Public MyValue As String
End Class

Public Class MyWebService
    ' Member variable to receive the contents of the MyHeader SoapHeader.
    Public myHeader As MyHeader
    
    ' Member variable to receive all headers other than MyHeader.
    Public unknownHeaders() As SoapUnknownHeader
    
    ' Receive any SOAP headers other than MyHeader.
    <WebMethod, _
        SoapHeader("myHeader", Direction := SoapHeaderDirection.InOut), _
        SoapHeader("unknownHeaders")> _
    Public Sub Hello()        
        
        ' Process the MyHeader SoapHeader.
        If myHeader.MyValue = "Some string" Then
            ' Process the header.
        End If 
        Dim header As SoapHeader
        For Each header In  unknownHeaders
            ' Perform some processing on header
            ' For those headers that cannot be processed, 
            ' set the DidUnderstand to false.
            header.DidUnderstand = False
        Next header
    End Sub
End Class

' </Snippet1>
