        Protected Overrides Function _
            GetErrorDesignTimeHtml(ByVal exc As Exception) As String

            Return CreatePlaceHolderDesignTimeHtml( _
                "ASPNET.Examples: An error occurred while rendering the GridView.")

        End Function