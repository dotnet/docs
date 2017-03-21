      ' Using method RemoveAt.
      If Not customErrorsSection.SectionInformation.IsLocked Then
         ' Remove the error at 0 index
         customErrorsCollection.RemoveAt(0)
         configuration.Save()
      End If
      