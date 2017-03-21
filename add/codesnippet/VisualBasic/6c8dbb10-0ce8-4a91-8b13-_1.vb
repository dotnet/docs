      ' Using the Set method.
        Dim newCustomError _
        As New CustomError(404, "customerror404.htm")
      
      ' Update the configuration file.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Add the new custom error to the collection.
         customErrorsCollection.Set(newCustomError)
         configuration.Save()
      End If
      