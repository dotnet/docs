' System.Web.Services.Protocols.SoapHeaderException(string, XmlQualifiedName, string, Exception)

'   The following example demonstrates the constructor 
'   'SoapHeaderException(string, XmlQualifiedName, string, Exception)' 
'   of the 'SoapHeaderException' class. The XML Web service method 
'   throws an 'SoapHeaderException' when an exception is thrown during
'   header processing. This exception is sent to the client
'   and the information leading to the exception is made
'   available on the client that invoked the XML Web service
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
      ' Process the header from the client.
      Try
         Dim j As Integer = 100 / mySoapHeader.number
      Catch e As Exception
         ' Throw a SoapHeaderException if an exception is caught during
         ' header processing.
         Throw New SoapHeaderException( _
            "An Exception was thrown during the processing of header", _
            SoapException.ClientFaultCode, _
            "http://localhost/MathSvc_SoapHeaderException4.vb.asmx/Add", e)
      End Try
      Return xValue + yValue
   End Function 'Add
End Class 'MathSvc
' </Snippet1>
