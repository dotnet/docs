Imports System
Imports System.Net
Imports System.Web
Imports System.Web.Services
Imports System.Security.Cryptography.X509Certificates

Public Class Sample
    Private myUri As Uri    
    
    Public Sub Method()
        
' <Snippet1>
 ServicePointManager.CertificatePolicy = New MyCertificatePolicy()
        
 ' Create the request and receive the response
 Try
     Dim myRequest As WebRequest = WebRequest.Create(myUri)
     Dim myResponse As WebResponse = myRequest.GetResponse()
     
     ProcessResponse(myResponse)

     myResponse.Close()
     
 ' Catch any exceptions
 Catch e As WebException
     If e.Status = WebExceptionStatus.TrustFailure Then
         ' Code for handling security certificate problems goes here.
     End If
     ' Other exception handling goes here
  End Try

' </Snippet1>
 End Sub  

    ' Method added so sample will compile
    Public Sub ProcessResponse(resp As WebResponse)
    End Sub
    
End Class

' Class added so sample will compile
Public Class MyCertificatePolicy
    Implements ICertificatePolicy

    Public Function CheckValidationResult(srvPoint As System.Net.ServicePoint, _
    certificate As System.Security.Cryptography.X509Certificates.X509Certificate, _
    request As System.Net.WebRequest, _
    certificateProblem As Integer) As Boolean _
    Implements ICertificatePolicy.CheckValidationResult
    
        Return True
    End Function
End Class