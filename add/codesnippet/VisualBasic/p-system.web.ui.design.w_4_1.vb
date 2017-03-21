        ' Generate design time markup.
        Public Overrides Function GetDesignTimeHtml() As String
            ' Generate a design-time placeholder containing the 
            ' DataFile and the ConnectionString properties.
            ' Split the ConnectionString into segments so it doesn't make
            ' placeholder too wide.
            Dim connectParts() As String
            connectParts = GetConnectionString().Split((";").ToCharArray())
            Dim connectString As String
            connectString = "&nbsp;&nbsp;" & connectParts(0)

            Dim i As Integer
            For i = 1 To connectParts.Length - 1
                connectString &= ";<br>&nbsp;&nbsp;" & connectParts(i).Trim()
            Next

            Return CreatePlaceHolderDesignTimeHtml( _
                "DataFile: " & DataFile & "<br />" & _
                "Connection string:<br />" & connectString)
        End Function