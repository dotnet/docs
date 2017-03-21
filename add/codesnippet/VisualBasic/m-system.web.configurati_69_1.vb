      ' Using the Clear method.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Execute the Clear method.
         customErrorsCollection.Clear()
         configuration.Save()
      End If
      