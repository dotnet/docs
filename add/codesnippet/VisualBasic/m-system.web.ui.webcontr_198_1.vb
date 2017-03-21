      Public Overrides Sub SyncChanges()
        Dim part As TextDisplayWebPart = CType(WebPartToEdit, _
                                               TextDisplayWebPart)
        Dim currentStyle As String = part.FontStyle

        ' Select the current font style in the drop-down control.
        Dim item As ListItem
        For Each item In PartContentFontStyle.Items
          If item.Value = currentStyle Then
            item.Selected = True
            Exit For
          End If
        Next item

      End Sub