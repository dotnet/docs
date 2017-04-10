Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' <Snippet1>
Public Class MyHeader
    Inherits SoapHeader
    Public MyValue As String
End Class

Public Class MyWebService
    
    Public myHeader As MyHeader    
    
    <WebMethod, _
    SoapHeader("myHeader", _
                Direction := SoapHeaderDirection.InOut Or SoapHeaderDirection.Fault)> _
    Public Sub MySoapHeaderReceivingMethod()

        ' Set myHeader.MyValue to some value.
        
    End Sub
    
End Class

' </Snippet1>
