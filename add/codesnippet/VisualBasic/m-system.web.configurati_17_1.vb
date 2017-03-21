      ' Using the Remove method.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Remove the error with statuscode 404.
         customErrorsCollection.Remove("404")
         configuration.Save()
      End If
      