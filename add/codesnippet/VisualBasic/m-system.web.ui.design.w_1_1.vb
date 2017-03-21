        ' Generate the design-time markup for the control 
        ' when the template is empty.
        Protected Overrides Function GetEmptyDesignTimeHtml() As String

            Dim noElements As String = "Contains no menu items."

            Return CreatePlaceHolderDesignTimeHtml(noElements)

        End Function ' GetEmptyDesignTimeHtml