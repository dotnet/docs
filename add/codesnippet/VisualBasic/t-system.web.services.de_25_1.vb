   ' Creates an Import object with namespace and location.
   Public Shared Function CreateImport(targetNamespace As String, _
      targetlocation As String) As Import
      Dim myImport As New Import()
      myImport.Location = targetlocation
      myImport.Namespace = targetNamespace
      Return myImport
   End Function 'CreateImport