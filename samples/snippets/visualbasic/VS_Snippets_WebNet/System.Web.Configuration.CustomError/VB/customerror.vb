
Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.CustomError members selected by the user.

Class UsingCustomError
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim customErrors As CustomErrorsSection = _
         CType(configuration.GetSection( _
         "system.web/customErrors"), CustomErrorsSection)
      
      ' Get the collection.
        Dim customErrorsCollection _
        As CustomErrorCollection = _
        customErrors.Errors
      
      ' </Snippet1>
      
      ' <Snippet2>
      ' Create a new error object.
      'Does not exist anymore.
      'Dim newcustomError As New CustomError()
      
      ' </Snippet2>
      
      ' <Snippet3>
      ' Create a new error object.
        Dim newcustomError2 _
        As New CustomError(404, "customerror404.htm")
      ' </Snippet3>
      
      ' <Snippet4>
      ' Get first errorr Redirect.
        Dim currentError0 As CustomError = _
        customErrorsCollection(0)
        Dim currentRedirect As String = _
        currentError0.Redirect
      
      ' Set first error Redirect.
      currentError0.Redirect = "customError404.htm"
      
      ' </Snippet4>
      ' <Snippet5>
      ' Get second error StatusCode.
        Dim currentError1 As CustomError = _
        customErrorsCollection(1)
        Dim currentStatusCode As Integer = _
        currentError1.StatusCode
      
      ' Set the second error StatusCode.
        currentError1.StatusCode = 404
        ' </Snippet5>
   End Sub 'Main 
End Class 'UsingCustomError 


