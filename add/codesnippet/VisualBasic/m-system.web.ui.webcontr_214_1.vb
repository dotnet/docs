      Public Overrides Function ApplyChanges() As Boolean
        Dim part As TextDisplayWebPart = CType(WebPartToEdit, _
                                               TextDisplayWebPart)
        ' Update the custom WebPart control with the font style.
        part.FontStyle = PartContentFontStyle.SelectedValue

        Return True

      End Function