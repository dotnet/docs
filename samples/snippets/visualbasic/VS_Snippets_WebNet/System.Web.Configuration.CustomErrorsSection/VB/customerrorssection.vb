
Imports System
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.CustomErrorsSection
' members selected by the user.

Class UsingCustomErrorsSection
   
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      
      ' Get the section.
        Dim customErrorsSection _
        As CustomErrorsSection = _
        CType(configuration.GetSection( _
  "system.web/customErrors"), _
  CustomErrorsSection)
      
      ' Get the collection
        Dim customErrorsCollection _
        As CustomErrorCollection = customErrorsSection.Errors
      
      ' </Snippet1>
      
      ' <Snippet2>
      ' Create a new CustomErrorCollection object.
        Dim newcustomErrorCollection = _
        New System.Web.Configuration.CustomErrorCollection()
      
      ' </Snippet2>
      
      ' <Snippet3>
      ' Get the currentDefaultRedirect
        Dim currentDefaultRedirect As String = _
        customErrorsSection.DefaultRedirect
      
      ' </Snippet3>
      ' <Snippet4>
      ' Using the Set method.
        Dim newCustomError _
        As New CustomError(404, "customerror404.htm")
      
      ' Update the configuration file.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Add the new custom error to the collection.
         customErrorsCollection.Set(newCustomError)
         configuration.Save()
      End If
      
      ' </Snippet4>
      ' <Snippet5>
      ' Using the Add method.
        Dim newCustomError2 _
        As New CustomError(404, "customerror404.htm")
      
      ' Update the configuration file.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Add the new custom error to the collection.
         customErrorsCollection.Add(newCustomError2)
         configuration.Save()
      End If
      
      ' </Snippet5>
      
      ' <Snippet6>
      ' Using the Clear method.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Execute the Clear method.
         customErrorsCollection.Clear()
         configuration.Save()
      End If
      
      ' </Snippet6>
      ' <Snippet7>
      ' Using the Remove method.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Remove the error with statuscode 404.
         customErrorsCollection.Remove("404")
         configuration.Save()
      End If
      
      ' </Snippet7>
      
      ' <Snippet8>
      ' Using method RemoveAt.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Remove the error at 0 index
         customErrorsCollection.RemoveAt(0)
         configuration.Save()
      End If
      
      ' </Snippet8>
      
      ' <Snippet9>
      ' Get the current Mode.
        Dim currentMode _
        As CustomErrorsMode = customErrorsSection.Mode
      
      ' Set the current Mode.
        customErrorsSection.Mode = _
        CustomErrorsMode.RemoteOnly
      
      ' </Snippet9>
      ' <Snippet10>
      ' Get the error with collection index 0.
        Dim customError As CustomError = _
        customErrorsCollection(0)
      
      ' </Snippet10>
      ' <Snippet11>
      ' Get the error with status code 404.
        Dim customError1 As CustomError = _
        customErrorsCollection("404")
      
      ' </Snippet11>
      ' <Snippet12>
      ' Create a new CustomErrorsSection object.
        Dim newcustomErrorsSection _
        As New CustomErrorsSection()
        ' </Snippet12>

   End Sub 'Main
End Class 'UsingCustomErrorsSection 


