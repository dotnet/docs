' System.Web.Services.Protocols.SoapHeaderException(string, XmlQualifiedName)

'   The following example demonstrates the constructor 
'   'SoapHeaderException(string, XmlQualifiedName)'of the 
'   'SoapHeaderException' class. The web service method 
'   throws an exception whenever the value contained within 
'   the header is zero. This exception is sent to the client
'   and the information leading to the exception is made
'   available on the client that invoked the web service
'   method. 

' <Snippet1>
<%@ WebService Language="VB" Class="MathSvc" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class MySoapHeader
   Inherits SoapHeader
   Public number As Integer
End Class 'MySoapHeader

Public Class MathSvc
   Inherits WebService
   Public mySoapHeader As MySoapHeader

   <WebMethod(), SoapHeaderAttribute("mySoapHeader", _
      Direction := SoapHeaderDirection.In)>  _
   Public Function Add(xValue As Single, yValue As Single) As Single
      ' Throw an exception if the value received in the header is zero.
      If mySoapHeader.number = 0 Then
         Throw New SoapHeaderException( _
            "value received in the header is zero.", _
            SoapException.ClientFaultCode)
      End If
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc
' </Snippet1>