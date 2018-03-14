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
    
    Public myHeader As MyHeader
    
    ' Receive all SOAP headers besides the MyHeader SOAP header.
    Public unknownHeaders() As SoapUnknownHeader    

    'Receive any SOAP headers other than MyHeader.
    <WebMethod, _
    SoapHeader("myHeader", Direction := SoapHeaderDirection.InOut), _
    SoapHeader("unknownHeaders")> _
    Public Function MyWebMethod() As String
        Dim unknownHeaderAttributes As String = String.Empty
        
        ' Set myHeader.MyValue to some value.
        Dim header As SoapUnknownHeader
        For Each header In  unknownHeaders
            ' Perform some processing on the header.
            Dim attribute As XmlAttribute
            For Each attribute In header.Element.Attributes
                unknownHeaderAttributes &= attribute.Name & ":" & _
                    attribute.Value & ";"
            Next attribute
            ' For those headers that cannot be 
            ' processed, set the DidUnderstand property to false.
            header.DidUnderstand = False
        Next header
        
        Return unknownHeaderAttributes
        
    End Function
End Class

' </Snippet1>
