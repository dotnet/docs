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
