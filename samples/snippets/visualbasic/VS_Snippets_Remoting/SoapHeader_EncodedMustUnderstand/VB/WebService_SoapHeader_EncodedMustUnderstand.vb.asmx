<%@ WebService Language="VB" Class="WebService_SoapHeader_EncodedMustUnderstand" %>

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class MyHeader
   Inherits SoapHeader
   Public MyValue As String
End Class 'MyHeader

Public Class WebService_SoapHeader_EncodedMustUnderstand
   Inherits System.Web.Services.WebService
   Public myHeader1 As MyHeader
   ' Receive all SOAP headers besides the MyHeader SOAP header.
   Public unknownHeaders() As SoapUnknownHeader
   
   <WebMethod(Description := "This Web Service method requires a client to send the MyHeader SOAP header."), _
         SoapHeader("myHeader1", Direction := SoapHeaderDirection.In, Required := True), _
         SoapHeader("unknownHeaders", Required := False)>  _
   Public Function MyWebMethod1() As String
      
      ' Receive any SOAP headers other than MyHeader.
      
      Dim myUnknownHeader As SoapUnknownHeader
      For Each myUnknownHeader In  unknownHeaders
         ' Perform some processing on header.
         If myUnknownHeader.Element.Name = "MyKnownHeader" Then
            myUnknownHeader.DidUnderstand = True
         Else
            ' Set the DidUnderstand to false.
            myUnknownHeader.DidUnderstand = False
         End If
      Next myUnknownHeader
      Return "WebMethod1 called."
   End Function 'MyWebMethod1
   
   <WebMethod(Description := "This Web Service method requires a client to send the MyHeader SOAP header."), _
            SoapHeader("myHeader1", Direction := SoapHeaderDirection.In, Required := True), _
            SoapHeader("unknownHeaders", Required := False)>  _
   Public Function MyWebMethod2() As String
      ' Receive any SOAP headers other than MyHeader.
      myHeader1.DidUnderstand = False
      Dim myUnknownHeader As SoapUnknownHeader
      For Each myUnknownHeader In  unknownHeaders
         ' Perform some processing on header.
         If myUnknownHeader.Element.Name = "MyKnownHeader" Then
            myUnknownHeader.DidUnderstand = True
         Else
            ' Set the DidUnderstand to false.
            myUnknownHeader.DidUnderstand = False
         End If
      Next myUnknownHeader
      Return "Web Method2 Called."
   End Function 'MyWebMethod2
End Class 'WebService_SoapHeader_EncodedMustUnderstand