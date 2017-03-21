      ' Using the Add method.
        Dim newCustomError2 _
        As New CustomError(404, "customerror404.htm")
      
      ' Update the configuration file.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Add the new custom error to the collection.
         customErrorsCollection.Add(newCustomError2)
         configuration.Save()
      End If
      