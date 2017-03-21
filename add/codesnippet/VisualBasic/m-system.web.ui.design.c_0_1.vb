        ' Generate the design-time markup for the control when an error occurs.
        Protected Overrides Function GetErrorDesignTimeHtml( _
            ByVal ex As Exception) As String

            ' Write the error message text in red, bold.
            Dim errorRendering As String = _
                "<span style=""font-weight:bold; color:Red; "">" & _
                ex.Message & "</span>"

            Return CreatePlaceHolderDesignTimeHtml(errorRendering)

        End Function ' GetErrorDesignTimeHtml