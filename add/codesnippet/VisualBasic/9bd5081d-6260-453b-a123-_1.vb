        ' Add instructions to the placeholder view of the control
        Public Overloads Overrides Function GetDesignTimeHtml() As String
            Return CreatePlaceHolderDesignTimeHtml("Click here and use " & _
                "the task menu to edit the templates.")
        End Function