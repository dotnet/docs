        <ConnectionProvider("Row")> _
        Public Function GetConnectionInterface() As IWebPartRow
            Return New RowProviderWebPart()

        End Function 'GetConnectionInterface