 ' <Snippet1>
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Define a SOAP header by deriving from the SoapHeader base class.
' The header contains just one string value.
Public Class MyHeader
   Inherits SoapHeader
   Public MyValue As String
End Class 'MyHeader


Public Class MyWebService
   ' Member variable to receive the contents of the MyHeader SOAP header.
   Public myHeader As MyHeader

   
   <WebMethod, _ 
    SoapHeader("myHeader", Direction := SoapHeaderDirection.InOut)> _
   Public Sub Hello()

   End Sub 'Hello
End Class 'MyWebService

' </Snippet1>
