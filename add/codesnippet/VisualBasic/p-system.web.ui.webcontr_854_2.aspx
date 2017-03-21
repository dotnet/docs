  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
      ImportCatalogPart1.Title = "Import Server Controls"
      ImportCatalogPart1.BrowseHelpText = "Enter the path to a " _
        & "description file."
      ImportCatalogPart1.UploadButtonText = "Upload Description"
      ImportCatalogPart1.UploadHelpText = "Upload a description file."
      ImportCatalogPart1.ImportedPartLabelText = "Imported Controls"
      ImportCatalogPart1.PartImportErrorLabelText = "An error occured " _
        & "during the import process."
  End Sub