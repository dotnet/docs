        Protected Overrides Function GetEmptyDesignTimeHtml() As String
            Dim emptyText As String

            ' Check the CanEnterTemplateMode property to
            ' specify which text to display if ItemTemplate 
            ' does not contain a value.
            If CanEnterTemplateMode Then
                emptyText = _
                    "<b>Either the Enabled property value is false " + _
                    "or you need to set the ItemTemplate for this " + _
                    "control.<br>Right-click to edit templates.</b>"
            Else
                emptyText = _
                    "<b>You cannot edit templates in this view.<br>" + _
                    "Switch to HTML view to define the ItemTemplate.</b>"
            End If

            Return CreatePlaceHolderDesignTimeHtml(emptyText)
        End Function